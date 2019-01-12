using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class ProjectDoc
    {
        public int Id { get; set; }
        public String DocName { get; set; }
        public String DocUrl { get; set; }
        public String Desc { get; set; }
        public int ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
    }
}
