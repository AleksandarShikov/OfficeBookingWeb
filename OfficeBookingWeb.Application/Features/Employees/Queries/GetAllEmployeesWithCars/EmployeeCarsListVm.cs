using OfficeBookingWeb.Application.Features.DTOs;
using OfficeBookingWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployeesWithCars
{
    public class EmployeeCarsListVm
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public List<CarDto> Cars { get; set; }
    }
}
