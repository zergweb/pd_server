using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class LkUserSkill
    {
        public int Id { get; set; }

        public int LkStudentId { get; set; }
        public LkStudent LkStudent { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
