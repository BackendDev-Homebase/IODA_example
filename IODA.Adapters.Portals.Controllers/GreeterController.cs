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
            var visitorCounts = await _da.Load();

            var message = BusinessLogic.GetGreetingMessage(visitorCounts, name);

            await _da.Store(visitorCounts);

            return message;
        }

        [HttpGet("api/GetAllNames")]
        public async Task<ActionResult<List<string>>> GetAllNames()
        {
            // Integration
            var visitorCounts = await _da.Load();

            var visitors = BusinessLogic.GetAllVisitors(visitorCounts!);
            return await Task.FromResult(visitors);
        }

        [HttpDelete("api/DeleteWithMoreThan/{visits}")]
        public async Task DeleteWithMoreThan(int visits)
        {
            // Integration
            var visitorCounts = await _da.Load();

            BusinessLogic.RemoveVistorsWithMoreThan(visitorCounts, visits);

            await _da.Store(visitorCounts);
        }
    }
}