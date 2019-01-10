using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class SubjectTeacher
    {   
        public int Id { get; set; }

        public int SubjectId { get; set; }
        
        public Subject Subject { get; set; }

        public int LkTeacherId { get; set; }
        [JsonIgnore]
        public LkTeacher LkTeacher { get; set; }

        public int GroupId { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }
    }
}
