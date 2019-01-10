using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class Group
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Course { get; set; } 
        public FacultySection FacultySection { get; set; }
        [JsonIgnore]
        public List<LkStudent> Students { get; set; }
        public List<SubjectTeacher> Subjects { get; set; }
    }
}
