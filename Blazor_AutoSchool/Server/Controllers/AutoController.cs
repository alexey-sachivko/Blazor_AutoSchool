using Microsoft.AspNetCore.Mvc;

namespace Blazor_AutoSchool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly IAutoService _autoService;

        public AutoController(IAutoService autoService)
        {
            _autoService = autoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Auto>>>> GetAutos()
        {
            var result = await _autoService.GetAutos();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<Auto>>> GetAuto(int id)
        {
            var result = await _autoService.GetAuto(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Auto>>> CreateAuto(Auto auto)
        {
            var result = await _autoService.CreateAuto(auto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Auto>>> UpdateAuto(Auto auto)
        {
            var result = await _autoService.UpdateAuto(auto);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteAuto(int id)
        {
            var result = await _autoService.DeleteAuto(id);

            return Ok(result);
        }
    }
}
    