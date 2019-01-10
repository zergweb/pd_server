using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class LkStudent
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String LastName { get; set; }
        public String City { get; set; }
        public LkImage Thumbnail { get; set; }
        public DateTime? DOB { get; set; }
        public List<Certificate> Certificates { get; set; }  
        public Portfolio Portfolio { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public String About { get; set; }
        public PublicProfileConfig Config { get; set; }
        public IEnumerable<StudentSkill> StudentSkills { get; set; }

    }
}
