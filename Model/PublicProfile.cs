using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class PublicProfile
    {
        public LkStudent Student { get; set; }
        public List<Certificate> Certificates { get; set; }
    }
}
