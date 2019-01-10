using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public String Name { get; set; }
        public DateTime? Date { get; set; }
        public bool IsShow { get; set; }
        public String GitUrl { get; set; }
        public String ShortDesc { get; set; }
        public String LongDesc { get; set; }
        public LkImage Thumbnail { get; set; }
        public ProjectGallery Gallery { get; set; }
        public String PresentationUrl { get; set; }
        //public ProjectDoc MainDoc { get; set; }
        public List<ProjectDoc> ProjectDocs { get; set; }

        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
