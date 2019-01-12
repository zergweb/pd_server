using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PdApi.Services.DbManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdApi.Controllers
{
    public class LkCertificatesController : Controller
    {
        public class ReqB
        {
            public int UserId;
        }
        private readonly IDbManager _dm;
        public LkCertificatesController(IDbManager dm)
        {
            _dm = dm;
        }
        [HttpPost("/getCertificates")]
        public async Task<ActionResult> GetCertificates([FromBody]ReqB body)
        {
            var t = await _dm.GetCertificates(body.UserId);
            if (t == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(t));
        }
    }
}
