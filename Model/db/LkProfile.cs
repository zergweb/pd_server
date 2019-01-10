using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Model
{
    public class LkProfile
    {
        public int Id { get; set; }

        public String About { get; set; }
        public int? UserInfoId { get; set; }
        public LkStudent UserInfo {get;set;}
    }
}
