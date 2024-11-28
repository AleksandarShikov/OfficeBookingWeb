using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficeBookingWeb.Application.Features.Employees.Command;
using OfficeBookingWeb.Application.Features.Employees.Queries;
using OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployees;
using OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployeesWithCars;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEmployees", Name = "GetAllEmployees")]
        public async Task<ActionResult<List<EmployeeListVm>>> GetAllEmployees()
        {
            var response = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(response);
        }

        [HttpGet("allwithcars", Name = "GetAllEmployeesWithCars")]
        public async Task<ActionResult<List<EmployeeListVm>>> GetAllEmployeesWithCars()
        {
            var response = await _mediator.Send(new EmployeeCarsListQuery());
            return Ok(response);
        }

        [HttpPost("addemployee", Name = "AddEmployee")]
        public async Task<ActionResult<int>> CreateEmployee([FromBody] CreateEmployeeCommand createEmployeeCommand)
        { 
            var response = await _mediator.Send(createEmployeeCommand);
            return Ok(response);
        }

        [HttpDelete("deleteemployee/{employeeId}", Name = "SoftDeleteEmployee")]
        public async Task<ActionResult<int>> DeleteEmployee(int employeeId)
        {
            var response = await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = employeeId });
            return Ok(response);
        }

        [HttpPut("updateemployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            var response = await _mediator.Send(updateEmployeeCommand);
            return Ok(response);

        }
    }


}

