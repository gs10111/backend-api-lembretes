using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }
        // GET: api/Reminder
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _reminderService.GetAllAsync();
            return Ok(categories);
        }

        // GET api/ReminderController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var reminder = await _reminderService.GetById(id);
            if (reminder == null)
            {
                return NotFound();
            }
            return Ok(reminder);
        }

        // POST api/ReminderController
        [HttpPost]
        public async Task<IActionResult> Post(Reminder reminder)
        {
            await _reminderService.CreateAsync(reminder);
            return Ok("Created Successfully");
        }

        // PUT api/ReminderController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Reminder newReminder)
        {
            var reminder = await _reminderService.GetById(id);
            if (reminder == null)
                return NotFound();
            await _reminderService.UpdateAsync(id, newReminder);
            return Ok("Updated Successfully");
        }

        // DELETE api/ReminderController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var reminder = await _reminderService.GetById(id);
            if (reminder == null)
                return NotFound();
            await _reminderService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}
