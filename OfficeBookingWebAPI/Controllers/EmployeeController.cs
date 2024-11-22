using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficeBookingWeb.Application.Features.Employees.DTOs;
using OfficeBookingWeb.Application.Features.Employees.Queries;
using OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployees;
using OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployeesWithCars;

namespace OfficeBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("all",Name = "GetAllEmployees")]
        public async Task<ActionResult<List<EmployeeListVm>>> GetAllEmployees()
        {
            var dtos = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithcars", Name = "GetAllEmployeesWithCars")]
        public async Task<ActionResult<List<EmployeeListVm>>> GetAllEmployeesWithCars()
        {
            var dtos = await _mediator.Send(new EmployeeCarsListQuery());
            return Ok(dtos);
        }
    }
}
