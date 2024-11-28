using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficeBookingWeb.Application.Features.OfficeRooms.Queries;

namespace OfficeBookingWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficeRoomController : Controller
    {
        private readonly IMediator _mediator;

        public OfficeRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllOfficeRooms", Name = "GetAllOfficeRooms")]
        public async Task<ActionResult<List<OfficeRoomListVm>>> GetAllOfficeRooms()
        {
            var response = await _mediator.Send(new GetOfficeRoomListQuery());
            return Ok(response);
        }
    }
}
