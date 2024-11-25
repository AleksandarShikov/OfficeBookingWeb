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
            this._mediator = mediator;
        }

        [HttpGet("getallemployees",Name = "GetAllEmployees")]
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

        [HttpPost("addemployee", Name = "AddEmployee")]
        public async Task<ActionResult<int>> CreateEmployee([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            if (createEmployeeCommand == null)
            {
                return BadRequest("Employee data is required.");
            }


            try
            {
                var response = await _mediator.Send(createEmployeeCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("softdeleteemployee/{employeeId}", Name = "SoftDeleteEmployee")]
        public async Task<ActionResult<int>> DeleteEmployee(int employeeId)
        {
            if (employeeId <= 0)
            {
                return BadRequest("Invalid employee ID.");
            }

            try
            {
                var result = await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = employeeId });

                if (!result)
                {
                    return NotFound("Employee not found.");
                }
                return Ok("Employee Deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateemployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            if (employeeId != updateEmployeeCommand.EmployeeId)
            {
                return BadRequest("Employee ID mismatch");
            }

            try
            {
                var result = await _mediator.Send(updateEmployeeCommand);
                if (result)
                {
                    return Ok("Employee Updated!");
                }
                return NotFound("Employee not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
