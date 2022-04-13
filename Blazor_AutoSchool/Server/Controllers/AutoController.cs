﻿using Microsoft.AspNetCore.Mvc;

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
    }
}
    