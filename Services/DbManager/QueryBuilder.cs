using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdApi.Model;
namespace PdApi.Services.DbManager
{
    public class QueryBuilder
    {
        private IQueryable<LkStudent> _query;
        private StudentSelectionModel _sm;
        
        public QueryBuilder(StudentSelectionModel sm, IQueryable<LkStudent> query)
        {
            _sm = sm;
            _query = query;

        }
        public IQueryable<LkStudent> getQuery(){
            SelectByName();
            SelectByCity();
            SelectBySkills();
            SelectByDOB();
            SelectByFaculties();
            SelectByFacultySections();
            return _query;
        }
        private void SelectByName()
        {
            if (_sm.FirstName != null && _sm.FirstName.Length>1)
            {
                _query = _query.Where(a => a.FirstName == _sm.FirstName);
            }
            if (_sm.SecondName != null && _sm.SecondName.Length>1)
            {
                _query = _query.Where(a => a.SecondName == _sm.SecondName);
            }
            if (_sm.LastName != null && _sm.LastName.Length>1)
            {
                _query = _query.Where(a => a.LastName == _sm.LastName);
            }
        }
        private void SelectByCity()
        {
            if (_sm.City != null && _sm.City.Length > 1)
            {
                _query = _query.Where(a => a.City == _sm.City);
            }
        }
        private void SelectBySkills()
        {
            if (_sm.Skills != null)
            {
                //foreach (String Skill in _sm.Skills)
                //{
                //    _query = _query.Where(s => s.StudentSkills.Where(x => x.Skill.Name == Skill).Count() > 0);
                //}
                _query = _query.Where(student => _sm.Skills.Any(skillName => student.StudentSkills.Any(skill => skill.Skill.Name == skillName)));
            }
            else
            {
                //var teststud = from stud in _conext.Students
                //               join studSkill in _context.StudentSkills on stud.Id equals studSkill.LkStudentId
                //               join skill in _context.Skills on studSkill.SkillId equals skill.Id
                //               where skill.Name == "c#" && stud.Id == 3
                //               group stud by stud.Id;
               
                
            }           
           // var test = teststud.ToList();
        }
        private void SelectByDOB()
        {
            if (_sm.DOBstart != null)
            {
                _query = _query.Where(x => x.DOB > _sm.DOBstart);
            }
            if (_sm.DOBstart != null)
            {
                _query = _query.Where(x => x.DOB < _sm.DOBstart);
            }
        }
        private void SelectByGroups()
        {
            if (_sm.Groups != null)
            {                               
                _query = _query.Where(s => _sm.Groups.Any(x=>x==s.Group.Name));               
            }
        }
        private void SelectBySubjects()
        {
            if (_sm.SubjectNames != null)
            {
                _query = _query.Where(student => _sm.SubjectNames
                .Any(subjectName=>student.Group.Subjects
                .Any(sub=>sub.Subject.Name==subjectName)));
            }
        }
        private void SelectByFaculties()
        {
            if (_sm.Faculties != null)
            {
                _query = _query.Where(student => _sm.Faculties
                .Any(faculty => student.Group.FacultySection.Faculty == faculty));
                
            }
        }
        private void SelectByFacultySections()
        {
            if (_sm.FacultySections != null)
            {
                _query = _query.Where(student => _sm.FacultySections
                .Any(facultySection => student.Group.FacultySection == facultySection));
            }
        }
    }
}
