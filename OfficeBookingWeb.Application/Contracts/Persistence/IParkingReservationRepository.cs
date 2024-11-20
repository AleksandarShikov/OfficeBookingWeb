using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Contracts.Persistence;

public interface IParkingReservationRepository : IAsyncRepository<ParkingReservation>
{
    
}