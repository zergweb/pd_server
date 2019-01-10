using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class Certificate
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Desc { get; set; }
        public LkImage Image { get; set; }
        [JsonIgnore]
        public int LkStudentId { get; set; }
        [JsonIgnore]
        public LkStudent Student { get; set; }
    }
}
