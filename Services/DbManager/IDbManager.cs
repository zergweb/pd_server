using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdApi.Model;
namespace PdApi.Services.DbManager
{
    public interface IDbManager
    {
        Task<LkStudent> GetStudent(int id);
        Task<List<LkStudent>> GetCustomStudentList(StudentSelectionModel sm);
        Task<PublicProfileConfig> GetPublicConfig(int userid);
        Task<List<LastProjectItem>> GetLastProjects(int userId);
        Task<List<FacultyToJson>> GetAllFaculties();
        Task UpdateStudent(LkStudent stud);
        Task<Portfolio> GetPortfolio(int userid);
        Task AddProject(Project p);
        Task UpdateProject(Project p);
        Task<Project> GetProject(int id);
        Task<List<Certificate>> GetCertificates(int id);
        Task<PublicProfile> GetPublicProfile(int id);
        Task<Portfolio> GetPublicPortfolio(int id);
        Task<List<LkStudent>> GetClassmates(int id);
        Task<List<LkTeacher>> GetTeachers(int id);
   
    }
}
