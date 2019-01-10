using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class FacultyToJson
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<FacultySection> FacultySections { get; set; }
    }
}
