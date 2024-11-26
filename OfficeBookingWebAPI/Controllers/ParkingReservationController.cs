using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficeBookingWeb.Application.Features.Employees.Command;
using OfficeBookingWeb.Application.Features.ParkingReservations.Command;

namespace OfficeBookingWebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ParkingReservationController : Controller
    {
        private readonly IMediator _mediator;
        public ParkingReservationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("CreateParkingReservation", Name = "ParkingReservationCreation")]
        public async Task<ActionResult<int>> CreateParkingReservation([FromBody] CreateParkingReservationCommand createParkingReservationCommand)
        { 
            var response = await _mediator.Send(createParkingReservationCommand); 
            return Ok(response);
        }
    }
}
