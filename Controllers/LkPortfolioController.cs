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
    public class LkPortfolioController : Controller
    {
        private readonly IDbManager _dm;
        public LkPortfolioController(IDbManager dm)
        {
            _dm = dm;
        }
        public class RequestBody2
        {

            public int UserId { get; set; }
        }
        [HttpGet("/t")]
        public async Task<ActionResult> Test()
        {
            
            return Ok("zsddfsg");
        }
        [HttpPost("/addProject")]
        public async Task<ActionResult> AddProject([FromBody]RequestBody body)
        {
            var t = body.Project;
            await _dm.AddProject(body.Project);
            return Ok();
        }
        [HttpPost("/getProject")]
        public async Task<ActionResult> GetProject([FromBody]RequestBody2 body)
        {
            var t = await _dm.GetProject(body.UserId);
            if (t==null)
            {
            return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(t));
        }
        [HttpPut("/updateProject")]
        public async Task<ActionResult> UpdateProject([FromBody]RequestBody body)
        {
            if (body.Project != null)
            {
                await _dm.UpdateProject(body.Project);
                return Ok();
            }
            return NotFound();
            
        }
        [HttpPost("/getPortfolio")]
        public async Task<ActionResult> GetPortfolio([FromBody]RequestBody2 body)
        {                    
                var portfolio = await _dm.GetPortfolio(body.UserId);
            return Ok(JsonConvert.SerializeObject(portfolio));
        }
        [HttpPost("/getPublicPortfolio")]
        public async Task<ActionResult> GetPublicPortfolio([FromBody]RequestBodyId body)
        {
            var portfolio = await _dm.GetPublicPortfolio(body.Id);
            return Ok(JsonConvert.SerializeObject(portfolio));
        }
    }
}