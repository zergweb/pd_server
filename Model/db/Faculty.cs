using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class Faculty
    {
        public int Id { get; set; }
        public String Name { get; set; }
        [JsonIgnore]
        public List<FacultySection> FacultySections { get; set; }
    }
}
