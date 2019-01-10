using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class StudentSkill
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int LkStudentId { get; set; }
        [JsonIgnore]
        public LkStudent LkStudent { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
