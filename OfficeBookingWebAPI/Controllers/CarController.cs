﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficeBookingWeb.Application.Features.Cars.Command;
using OfficeBookingWeb.Application.Features.Employees.Command;

namespace OfficeBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("createcar")]
        public async Task<ActionResult<int>> CreateCar([FromBody] CreateCarCommand createCarCommand)
        {
            var response = await _mediator.Send(createCarCommand);
            return Ok(response);
        }
    }
}
