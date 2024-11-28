using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands
{
    public class UpdateOfficePresenceCommand : IRequest<bool>
    {
        public int PresenceId { get; set; }

        public DateOnly PresenceDate { get; set; }

        public int EmployeeId { get; set; }

        public int? ReservationId { get; set; }

        public int RoomId { get; set; }

        public string? Notes { get; set; }
    }
}
