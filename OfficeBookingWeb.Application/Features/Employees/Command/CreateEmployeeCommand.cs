using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.Employees.Command
{
    public class CreateEmployeeCommand : IRequest<int>
    {
 
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public int DepartmentId { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

        public virtual Department Department { get; set; }

        public virtual ICollection<OfficePresence> OfficePresences { get; set; } = new List<OfficePresence>();

        public virtual ICollection<ParkingReservation> ParkingReservations { get; set; } = new List<ParkingReservation>();
    }
}
