using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Models;
using TaskManagerApp.Services;

namespace TaskManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        #region GetAll
        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllAsync();
            if (!tasks.Any())
                return NoContent();

            return Ok(tasks);
        }
        #endregion

        #region GetTaskById
        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }
        #endregion

        #region CreateTask
        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            if (task == null)
                return BadRequest("Task data is invalid.");

            var success = await _taskService.AddAsync(task);
            if (!success)
                return BadRequest("Invalid task data.");

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }
        #endregion

        #region UpdateTask
        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskItem task)
        {
            if (task == null || task.Id != id)
                return BadRequest("Task mismatch.");

            var success = await _taskService.UpdateAsync(task);
            if (!success)
                return NotFound();

            return NoContent();
        }
        #endregion

        #region DeleteTask
        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var success = await _taskService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
        #endregion
    }
}
