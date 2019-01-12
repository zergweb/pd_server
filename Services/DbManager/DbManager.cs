using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using PdApi.Model;
namespace PdApi.Services.DbManager
{
    public class DbManager : IDbManager
    {
        public PdDbContext _db;
        public DbManager(PdDbContext db)
        {
            _db = db;
        }
        public async Task<LkStudent> GetStudent(int id)
        {     
            var query = _db.Students
                .Include(d => d.StudentSkills).ThenInclude(p => p.Skill)
                .Include(x=>x.Config)
                .Include(x => x.Group).ThenInclude(p => p.Subjects).ThenInclude(c => c.Subject)
                .Include(x => x.Group).ThenInclude(p => p.FacultySection).ThenInclude(c => c.Faculty)
                .Include(x => x.Group).ThenInclude(p => p.Subjects).ThenInclude(c => c.LkTeacher)
                .Include(x => x.Portfolio)
                .Include(x => x.Thumbnail)
                .Where(x=>x.Id==id)
                ;
            
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<PublicProfileConfig> GetPublicConfig(int userid)
        {
            return await _db.PublicProfileConfigs.Where(x => x.LkStudentId == userid).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<Portfolio> GetPortfolio(int userid)
        {
            return await _db.Portfolios.Where(x => x.LkStudentId==userid)
                .Include(x=>x.Projects).ThenInclude(x=>x.Gallery)   
                .AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<List<LkStudent>> GetCustomStudentList(StudentSelectionModel sm)
        {
            
            IQueryable<LkStudent> query = _db.Students
                .Include(d => d.StudentSkills).ThenInclude(p => p.Skill)
                .Include(x => x.Group).ThenInclude(p => p.Subjects).ThenInclude(c => c.Subject)
                .Include(x => x.Group).ThenInclude(p => p.FacultySection).ThenInclude(c => c.Faculty)
                .Include(x => x.Group).ThenInclude(p => p.Subjects).ThenInclude(c => c.LkTeacher)
                .Include(x => x.Portfolio)
                .Include(x => x.Thumbnail)
                ;     
            query = new QueryBuilder(sm, query).getQuery();
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<List<LastProjectItem>> GetLastProjects(int userId)
        {
        return await _db.Projects.Where(x=>x.Portfolio.LkStudent.Id== userId)
                .Take(3).OrderByDescending(x=>x.ProjectId)
                .Select(x=>new LastProjectItem {
                    Id =x.ProjectId,
                    Name =x.Name})
                .AsNoTracking().ToListAsync();
        }
        public Task UpdateStudent(LkStudent stud)
        {
            _db.Students.Update(stud);
            return _db.SaveChangesAsync();

        }
        public async Task<List<FacultyToJson>> GetAllFaculties()
        {
            return await _db.Faculties
                .Include(x => x.FacultySections)
                .Select(x => new FacultyToJson {
                    Id = x.Id,
                    Name=x.Name,
                    FacultySections=x.FacultySections
                })
                .AsNoTracking().ToListAsync();
        }

        public Task AddProject(Project p)
        {
            _db.Projects.Add(p);
           return _db.SaveChangesAsync();
        }
        public Task<Project> GetProject(int id)
        {
            return _db.Projects.Include(x => x.ProjectDocs)
                .Where(x=>x.ProjectId==id).AsNoTracking().FirstOrDefaultAsync();
                
        }
        public Task UpdateProject(Project p)
        {
            _db.Projects.Update(p);
            return _db.SaveChangesAsync();
        }
        public Task<List<Certificate>> GetCertificates(int id)
        {
            return _db.Certificate.Where(x=>x.LkStudentId==id).Include(x=>x.Image)
                .AsNoTracking().ToListAsync();
        }
        public async Task<PublicProfile> GetPublicProfile(int id)
        {
            var stud= await _db.Students.Where(x=>x.Id==id)
                .Include(d => d.StudentSkills).ThenInclude(p => p.Skill)
                .Include(x => x.Group).ThenInclude(p => p.Subjects).ThenInclude(c => c.Subject)
                .Include(x => x.Group).ThenInclude(p => p.FacultySection).ThenInclude(c => c.Faculty)
                .Include(x => x.Group).ThenInclude(p => p.Subjects).ThenInclude(c => c.LkTeacher)
                .Include(x => x.Portfolio)
                .Include(x => x.Thumbnail)
                .Include(x => x.Config)
                .AsNoTracking().FirstOrDefaultAsync();
            
            var cert = await _db.Certificate.Where(x => x.LkStudentId == id)
                .Include(x => x.Image).AsNoTracking().ToListAsync();

            return new PublicProfile { Student = stud, Certificates = cert};
        }
        public Task<Portfolio> GetPublicPortfolio(int id)
        {
            return _db.Portfolios.Where(x => x.Id==id)
                .Include(x => x.Projects)
                .Select(p=>new Portfolio
                {
                    Id=p.Id,
                    LkStudentId=p.Id,
                    Projects=p.Projects.Where(x=>x.IsShow).ToList()
                })
                .AsNoTracking().FirstOrDefaultAsync();
        }
        public Task<List<LkStudent>> GetClassmates(int id)
        {
            var grId = _db.Groups.Where(x => x.Students.Any(s => s.Id == id))
                .Select(z=>z.Id)
                .FirstOrDefault();          
            return _db.Students
                .Where(x => x.GroupId == grId && x.Id!=id)
                .AsNoTracking().ToListAsync();
        }
        public Task<List<LkTeacher>> GetTeachers(int id)
        {
            //var teachers = from teacher in _db.Teachers
            //               join subjectTeacher in _db.SubjectTeachers on teacher.Id equals subjectTeacher.LkTeacherId
            //               join Group in _db.Groups.Where(x=>x.Students.Where(s=>s.Id==id).First().GroupId==x.Id)
            //               on subjectTeacher.GroupId equals Group.Id
            //               where Group.Id==id
            //               group teacher by teacher.LastName;
            var teachers = from teacher in _db.Teachers
                           join subjectTeacher in _db.SubjectTeachers on teacher.Id equals subjectTeacher.LkTeacherId
                           join Group in _db.Groups on subjectTeacher.GroupId equals Group.Id
                           join stud in _db.Students on Group.Id equals stud.GroupId
                           where stud.Id == id
                           select teacher;                           
            return teachers.AsNoTracking().ToListAsync();
        }
    }
}
