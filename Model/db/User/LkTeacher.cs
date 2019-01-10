using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class LkTeacher
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String LastName { get; set; }
        public LkImage Thumbnail { get; set; }
        public DateTime? DOB { get; set; }
        public List<SubjectTeacher> SubjectTeachers { get; set; }

    }
}
