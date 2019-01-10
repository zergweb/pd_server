using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class Skill
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Desc { get; set; }
        [JsonIgnore]
        public IEnumerable<StudentSkill> StudentSkills { get; set; }
    }
}
