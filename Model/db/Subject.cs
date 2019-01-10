using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public String Name { get; set; }
        [JsonIgnore]
        public List<SubjectTeacher> SubjectTeachers { get; set; }
    }
}
