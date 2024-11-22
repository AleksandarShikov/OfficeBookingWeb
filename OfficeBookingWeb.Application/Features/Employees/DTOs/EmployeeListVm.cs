using OfficeBookingWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBookingWeb.Application.Features.Employees.DTOs
{
    public class EmployeeListVm
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public int DepartmentId { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<OfficePresence> OfficePresences { get; set; } = new List<OfficePresence>();

        public virtual ICollection<ParkingReservation> ParkingReservations { get; set; } = new List<ParkingReservation>();
    }
}
