using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands
{
    public class CreateOfficePresenceWithReservationCommand : IRequest<int>
    {
        public DateOnly PresenceDate { get; }
        public int EmployeeId { get; }
        public int RoomId { get; }
        public string? Notes { get; }


        public int ParkingSpotId { get; }
        public DateTime ArrivalTime { get; }
        public DateTime DepartureTime { get; }

        public bool IsReservationRequired { get; }
        public CreateOfficePresenceWithReservationCommand(DateOnly presenceDate, int employeeId, int roomId,
            string notes, int parkingSpotId, DateTime arrivalTime, DateTime departureTime, bool isReservationRequired)
        {
            PresenceDate = presenceDate;
            EmployeeId = employeeId;
            RoomId = roomId;
            Notes = notes;
            ParkingSpotId = parkingSpotId;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
            IsReservationRequired = true;
        }
    }
}
