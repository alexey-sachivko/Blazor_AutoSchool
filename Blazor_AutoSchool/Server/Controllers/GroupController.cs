using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_AutoSchool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Group>>>> GetGroups()
        {
            var result = await _groupService.GetGroups();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<Group>>> GetGroup(int id)
        {
            var result = await _groupService.GetGroup(id);

            return Ok(result);
        }
    }
}
