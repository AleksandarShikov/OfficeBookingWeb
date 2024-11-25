using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBookingWeb.Application.Features.ParkingReservations.Command
{
    public class CreateParkingReservationCommand : IRequest<bool>
    {
        public int EmployeeId { get; set; }

        public int ParkingSpotId { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public DateTime? DepartureTime { get; set; }

    }
}
