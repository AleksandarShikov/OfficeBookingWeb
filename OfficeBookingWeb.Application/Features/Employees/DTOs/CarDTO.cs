using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBookingWeb.Application.Features.Employees.DTOs
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public int EmployeeId { get; set; }
        public string CarBrand { get; set; }
        public string RegisterNumber { get; set; }
    }
}
