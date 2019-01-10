using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class PublicProfileConfig
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int LkStudentId { get; set; }
        [JsonIgnore]
        public LkStudent Student { get; set; }

        public bool Skills { get; set; }
        public bool DOB { get; set; }
        public bool Certificates { get; set; }
        public bool LastProjects { get; set; }
        public bool Portfolio { get; set; }
        public bool City { get; set; }
        public bool About { get; set; }
        public bool Course {get;set;}
        public bool Group { get; set; }
        public bool Faculty { get; set; }
        public bool FacucltySection { get; set; }
        public bool ExtraInfo { get; set; }

    }
}
