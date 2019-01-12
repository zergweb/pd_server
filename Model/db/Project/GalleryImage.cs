using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class GalleryImage
    {
        public int Id { get; set; }

        public int ProjectGalleryId { get; set; }
        [JsonIgnore]
        public ProjectGallery ProjectGallery { get; set; }

        public int LkImageId { get; set; }
        public LkImage LkImage { get; set; }
    }
}
