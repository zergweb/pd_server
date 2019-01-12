using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PdApi.Model;
using PdApi.Services.DbManager;

namespace PdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LkPublicPagesController : ControllerBase
    {      
            private readonly IDbManager _dm;
            public LkPublicPagesController(IDbManager dm)
            {
                _dm = dm;
            }
            [HttpPost("/getProfile")]
            public async Task<ActionResult> GetCertificates([FromBody]RequestBodyId body)
            {
                var t = await _dm.GetPublicProfile(body.Id);
                if (t == null)
                {
                    return NotFound();
                }
                return Ok(JsonConvert.SerializeObject(t));
            }
        [HttpGet("/getfaculties")]
        public async Task<ActionResult> GetAllFaculties()
        {
            var fac = await _dm.GetAllFaculties();
            if (fac == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(fac, Formatting.Indented));
        }
        
    }
}