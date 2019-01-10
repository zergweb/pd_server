using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class FacultySection
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String NumberName { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        [JsonIgnore]
        public List<Group> Groups {get;set;}
    }
}
