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
        public class RequestBody
        {
           
            public Project NewProject { get; set; }
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
            var t = body.NewProject;
            await _dm.AddProject(body.NewProject);
            return Ok();
        }
        [HttpPut("/updateProject")]
        public async Task<ActionResult> UpdateProject([FromBody]RequestBody body)
        {
           
            await _dm.UpdateProject(body.NewProject);
            return Ok();
        }
        [HttpPost("/getPortfolio")]
        public async Task<ActionResult> GetPortfolio([FromBody]RequestBody2 body)
        {
                     
                var portfolio = await _dm.GetPortfolio(body.UserId);
                return Ok(JsonConvert.SerializeObject(portfolio));
            
           
        }
    }
}