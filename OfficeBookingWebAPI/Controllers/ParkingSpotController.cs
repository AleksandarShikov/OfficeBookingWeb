using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OfficeBookingWeb.Application.Features.ParkingSpots.Queries;

namespace OfficeBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpotController : Controller
    {
        private readonly IMediator _mediator;

        public ParkingSpotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllParkingSpots", Name = "GetAllParkingSpots")]
        public async Task<ActionResult<List<ParkingSpotListVm>>> GetParkingSpots()
        {
            var response = await _mediator.Send(new GetParkingSpotListQuery());
            return Ok(response);
        }

    }
}
