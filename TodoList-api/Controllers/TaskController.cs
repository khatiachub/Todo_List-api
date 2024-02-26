using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoList_api.DB;
using TodoList_api.models;

namespace TodoList_api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]


    public class TaskController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TaskController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var tasks = _context.tasks.ToList();
                if (tasks.Count == 0)
                {
                    return (NotFound("no taskssssssssss"));
                }
                return Ok(tasks);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

       

        [HttpPost]

        public IActionResult Post(Class model)
        {

            try

            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            };
        }

        [HttpPut]

        public IActionResult Put(Class model)
        {
            try
            {
                if (model == null || model.ID == 0)
                {
                    return NotFound("model or id is invalid");
                }
                var tasksid = _context.tasks.Find(model.ID);
                if (tasksid == null)
                {
                    return BadRequest("{model.TaskId} is not found");
                }
                tasksid.TaskName = model.TaskName;
                tasksid.TaskStatus = model.TaskStatus;
                _context.SaveChanges();
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var taskid = _context.tasks.Find(Id);
                if (taskid == null)
                {
                    return NotFound("id is not found {id}");
                }
                else
                {
                    _context.tasks.Remove(taskid);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
