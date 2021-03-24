using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ActivitiesController : BaseApiController
    {
        // Get List
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {   // Passing result to HandleResult method
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // Get one
        [HttpGet("{id}")] //activities/id
        public async Task<IActionResult> GetActivity(string id)
        {
            // Passing result to HandleResult method
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        // Edit
        [Authorize("IsActivityHoust")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(string id, Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        // Delete
        [Authorize("IsActivityHoust")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        // Add attendance for activity ar cancel
        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(string id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id }));
        }

    }
}