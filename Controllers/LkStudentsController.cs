using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using PdApi.Model;
using PdApi.Services.DbManager;

//using QueryDesignerCore;

namespace PdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LkStudentsController : Controller
    {
        private readonly PdDbContext _context;
        private readonly IDbManager _dm;
        public LkStudentsController(PdDbContext context, IDbManager dm)
        {
            _context = context;
            _dm = dm;
        }
       
        public class UpdateStudBody
        {
            public LkStudent stud { get; set; }
            public StudentSelectionModel selectModel { get; set; }
        }
        [HttpPost("/updateStudent")]
        public async Task<ActionResult> UpdateStudent([FromBody]UpdateStudBody body)
        {
            await _dm.UpdateStudent(body.stud);
            return Ok();
        }
      
        [HttpPost("/selectStudents")]
        public async Task<ActionResult> selecteStudent([FromBody]UpdateStudBody body)
        {
            var students=await _dm.GetCustomStudentList(body.selectModel);           
            if (students == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(students));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LkStudent>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }
        
        [HttpGet("/teststud")]
        public async Task<ActionResult> GetTest()
        {
            var lkStudent = await _dm.GetStudent(1);
            var r = Request;
            if (lkStudent == null)
            {
                return NotFound();
            }

            return Ok(JsonConvert.SerializeObject(lkStudent, Formatting.Indented));
        }
        [HttpPost("/getStudent")]
        public async Task<ActionResult> GetStudent([FromBody]RequestBodyId test)
        {
            var lkStudent =await _dm.GetStudent(test.Id);
            var r = Request;
            if (lkStudent == null)
            {
                return NotFound();
            }
           
            return Ok(JsonConvert.SerializeObject(lkStudent));
        }
        [HttpPost("/getClassmates")]
        public async Task<ActionResult> GetСlassmates([FromBody]RequestBodyId test)
        {
            var lkStudents = await _dm.GetClassmates(test.Id);
            if (lkStudents == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(lkStudents));
        }
        [HttpPost("/getTeachers")]
        public async Task<ActionResult> GetTeachers([FromBody]RequestBodyId test)
        {
            var lkStudents = await _dm.GetTeachers(test.Id);
            if (lkStudents == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(lkStudents));
        }
        [HttpPost("/getprofileconfig")]
        public async Task<ActionResult> GetConfig([FromBody]RequestBodyId test)
        {
            var lkConfig = await _dm.GetPublicConfig(test.Id);
            if (lkConfig == null)
            {
                return NotFound();
            }

            return Ok(JsonConvert.SerializeObject(lkConfig, Formatting.Indented));
        }
        [HttpPost("/getallfaculties")]
        public async Task<ActionResult> GetAllFaculties()
        {
            var fac = await _dm.GetAllFaculties();
            if (fac == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(fac));
        }
        [HttpPost("/getlastprojects")]
        public async Task<ActionResult> GetLastProjects([FromBody]RequestBodyId test)
        {
            var lkConfig = await _dm.GetLastProjects(test.Id);
            if (lkConfig == null)
            {
                return NotFound();
            }

            return Ok(JsonConvert.SerializeObject(lkConfig));
        }
        [HttpGet("/test")]
        public async Task<ActionResult> GetStudentBySkill()
        {
            //var lang = "c#";
            //string query = @"SELECT pd.students.* FROM pd.studentskills 
            //              left join pd.students
            //              on pd.studentskills.LkStudentId = pd.students.Id
            //              left join pd.skills
            //              on pd.studentskills.SkillId = pd.skills.Id
            //              where pd.skills.Name = {0}";
            //var teststud = from stud in _context.Students
            //               join studSkill in _context.StudentSkills on stud.Id equals studSkill.LkStudentId
            //               join skill in _context.Skills on studSkill.SkillId equals skill.Id
            //               where skill.Name=="c#" && stud.Id==3
            //               group stud by stud.Id;
            //var test = await teststud.ToListAsync();

            //var filter = new FilterContainer
            //{
            //    Where = new TreeFilter
            //    {
            //        Field = "Id",
            //        FilterType = WhereFilterType.Equal,
            //        Value = 1
            //    },
            //    OrderBy = new List<OrderFilter>
            //    {
            //        new OrderFilter
            //        {
            //            Field = "Id",
            //            Order = OrderFilterType.Desc
            //        }
            //    }

            //};

            //var lkStudent = _context.Students
            //    //.FromSql(query, lang);
            //    //.Include(p => p.Certificates).ThenInclude(p => p.Image)
            //    .Include(d => d.StudentSkills).ThenInclude(p => p.Skill)
            //    //.Request(filter)
            //    .Where(a=>a.StudentSkills.Where(s=>s.Skill.Name=="python").Count()>0)
            //    .ToList();
           
            var lkStudent = await _dm.GetCustomStudentList(new StudentSelectionModel { });
            if (lkStudent == null)
            {
                return NotFound();
            }

            return Ok(Json(lkStudent));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLkStudent(int id, LkStudent lkStudent)
        {
            if (id != lkStudent.Id)
            {
                return BadRequest();
            }

            _context.Entry(lkStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LkStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
      
        [HttpPost]
        public async Task<ActionResult<LkStudent>> PostLkStudent(LkStudent lkStudent)
        {
            _context.Students.Add(lkStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLkStudent", new { id = lkStudent.Id }, lkStudent);
        }

        // DELETE: api/LkStudents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LkStudent>> DeleteLkStudent(int id)
        {
            var lkStudent = await _context.Students.FindAsync(id);
            if (lkStudent == null)
            {
                return NotFound();
            }

            _context.Students.Remove(lkStudent);
            await _context.SaveChangesAsync();

            return lkStudent;
        }

        private bool LkStudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
