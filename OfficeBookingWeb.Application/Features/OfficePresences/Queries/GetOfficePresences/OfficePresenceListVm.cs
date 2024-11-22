using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;

public class OfficePresenceListVm
{
    public int PresenceId { get; set; }

    public DateOnly PresenceDate { get; set; }

    public int EmployeeId { get; set; }

    public int? ReservationId { get; set; }

    public int RoomId { get; set; }

    public string? Notes { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ParkingReservation? Reservation { get; set; }

    public virtual OfficeRoom Room { get; set; }
}