using Microsoft.AspNetCore.Mvc;
using IODA.Domain;
using IODA.Adapters.Providers;

namespace IODA.Adapters.Portal.Controllers
{
    [ApiController]
    public class GreeterController : ControllerBase
    {
        private readonly DataAccess _da;

        public GreeterController(DataAccess da)
        {
            _da = da;
        }

        [HttpGet("api/GetGreetingMessage/{name}")]
        public async Task<string> GetGreetingMessage(string name)
        {
            // Integration
            var userCounts = await _da.Load();

            var message = BusinessLogic.GetGreetingMessage(userCounts, name);

            await _da.Store(userCounts);

            return message;
        }

        [HttpGet("api/GetAllNames")]
        public async Task<ActionResult<List<string>>> GetAllNames()
        {
            // Integration
            var userCounts = await _da.Load();

            var users = BusinessLogic.GetAllUsers(userCounts!);
            return await Task.FromResult(users);
        }

        [HttpDelete("api/DeleteWithMoreThan/{visits}")]
        public async Task DeleteWithMoreThan(int visits)
        {
            // Integration
            var userCounts = await _da.Load();

            BusinessLogic.RemoveUsersWithMoreThan(userCounts, visits);

            await _da.Store(userCounts);
        }
    }
}