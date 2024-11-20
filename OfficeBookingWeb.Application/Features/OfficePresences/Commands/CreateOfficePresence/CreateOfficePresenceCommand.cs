using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OfficeBookingWeb.Domain.Entities;


namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands.CreateOfficePresence
{
    public class CreateOfficePresenceCommand : IRequest<int>
    {
        public int PresenceId { get; set; }

        public DateOnly PresenceDate { get; set; }

        public int EmployeeId { get; set; }

        public int? ReservationId { get; set; }

        public int RoomId { get; set; }

        public string? Notes { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ParkingReservation Reservation { get; set; }

        public virtual OfficeRoom Room { get; set; }

        public override string ToString()
        {
            return $"Date present: {PresenceDate}, " +
                   $"{Employee.FullName}, " +
                   $"{Room.RoomNumber}, " +
                   $"{Employee.Department.DepartmentName}, " +
                   $"{Reservation.ParkingSpot.SpotNumber}, " +
                   $"{Reservation.ArrivalTime}, " +
                   $"{Reservation.DepartureTime}, " +
                   $"{Notes} ";
        }
    }
}
