using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class ProjectDoc
    {
        public int Id { get; set; }
        public String DocUrl { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
