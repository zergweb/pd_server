using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class ProjectGallery
    {
        public int Id { get; set; }
        public List<GalleryImage> GalleryImages { get; set; }

        public int ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
    }
}
