using OfficeBookingWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployees
{
    public class EmployeeListVm
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public int DepartmentId { get; set; }

    }
}
