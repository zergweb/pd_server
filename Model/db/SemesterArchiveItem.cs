using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class SemesterArchiveItem
    {
        public int Id { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

     }
}
