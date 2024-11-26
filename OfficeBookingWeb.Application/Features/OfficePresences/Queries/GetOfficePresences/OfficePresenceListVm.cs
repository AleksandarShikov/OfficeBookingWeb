using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;

public class OfficePresenceListVm
{

    public DateOnly PresenceDate { get; set; }

    public string EmployeeFullName { get; set; }

    public string EmployeeDepartment { get; set; }

    public int? ParkingSpot { get; set; }

    public string RoomNumber { get; set; }

    public DateTime? ArrivalTime {get; set; }
    
    public DateTime? DepartureTime {get; set; }
    
    public string? Notes { get; set; }

}