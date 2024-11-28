using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployeesWithCars;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands;
using OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;

namespace OfficeBookingWebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OfficePresenceController : Controller
    {
        private readonly IMediator _mediator;

        public OfficePresenceController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("CreateOfficePresence", Name = "CreateOfficePresence")]
        public async Task<ActionResult<int>> CreateOfficePresence(
            CreateOfficePresenceCommand createOfficePresenceCommand)
        {
            var response = await _mediator.Send(createOfficePresenceCommand);
            return Ok(response);
        }

        [HttpGet("GetAllOfficePresences", Name = "GetAllOfficePresences")]
        public async Task<ActionResult<List<OfficePresenceListVm>>> GetAllOfficePresences()
        {
            var response = await _mediator.Send(new GetOfficePresenceListQuery());
            return Ok(response);
        }

        [HttpDelete("DeleteOfficePresence/{presenceId}", Name = "DeleteOfficePresence")]
        public async Task<ActionResult<bool>> DeleteOfficePresence(int presenceId)
        {
            var response = await _mediator.Send(new DeleteOfficePresenceCommand { PresenceId = presenceId });
            return Ok(response);
        }

        [HttpPut("UpdateOfficePresence/{presenceId}", Name = "UpdateOfficePresence")]
        public async Task<ActionResult<bool>> UpdateOfficePresence(int presenceId,
            [FromBody] UpdateOfficePresenceCommand updateOfficePresenceCommand)
        {
            var response = await _mediator.Send(updateOfficePresenceCommand);
            return Ok(response);
        }

    }
}
