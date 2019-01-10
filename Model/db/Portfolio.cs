using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class Portfolio
    {
        public int Id { get; set; }
        public List<Project> Projects { get; set; }
        [JsonIgnore]
        public int LkStudentId { get; set; }
        [JsonIgnore]
        public LkStudent LkStudent { get; set; }
    }
}
