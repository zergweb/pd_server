using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class StudentSelectionModel
    {
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String LastName { get; set; }
        public String City { get; set; }
        public DateTime? DOBstart { get; set; }
        public DateTime? DOBend { get; set; }
        public String[] Groups { get; set; }
        public String[] SubjectNames { get; set; }
        public String[] TeacherNames { get; set; }
        public List<Faculty> Faculties { get; set; }
        public List<FacultySection> FacultySections { get; set; }
        public String[] Skills { get; set; }
    }
}
