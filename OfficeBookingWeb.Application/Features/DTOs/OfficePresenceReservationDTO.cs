using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBookingWeb.Application.Features.DTOs
{
    public class OfficePresenceReservationDto
    {
        public DateOnly PresenceDate { get; set; }
        public int EmployeeId { get; set; }
        public int RoomId { get; set; }
        public string? Notes { get; set; }


        public int ParkingSpotId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }

        public bool IsReservationRequired { get; set; }
    }
}
