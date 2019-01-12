using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class RequestBody
    {
        public Project Project { get; set; }
        public Certificate Certificate { get; set; }
        public LkStudent LkStudent { get; set; }
    }
}
