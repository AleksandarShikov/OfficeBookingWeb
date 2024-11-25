using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Contracts.Persistence;

public interface IParkingReservationRepository : IAsyncRepository<ParkingReservation>
{
    Task<List<ParkingReservation>> GetExpiredReservationsAsync(DateTime currentTime);

    Task<IEnumerable<ParkingReservation>> GetConflictingReservationsAsync(int parkingSpotId, DateTime arrivalTime,
        DateTime departureTime);
}