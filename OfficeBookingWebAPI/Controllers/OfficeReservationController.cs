using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficeBookingWeb.Application.Features.DTOs;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands;

namespace OfficeBookingWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficeReservationController : Controller
    {
        private readonly IMediator _mediator;

        public OfficeReservationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("CreatePresenceWithReservation",Name = "CreatePresenceWithReservation")]
        public async Task<ActionResult> CreateOfficePresenceWithReservation(OfficePresenceReservationDto dto)
        {
            var command = new CreateOfficePresenceWithReservationCommand( dto.PresenceDate, dto.EmployeeId,
                dto.RoomId, dto.Notes, dto.ParkingSpotId, 
                dto.ArrivalTime, dto.DepartureTime, dto.IsReservationRequired);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
