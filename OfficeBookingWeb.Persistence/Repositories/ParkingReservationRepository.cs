using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Persistence.Repositories
{
    public class ParkingReservationRepository : BaseRepository<ParkingReservation>, IParkingReservationRepository
    {
        public ParkingReservationRepository(OfficeBookingWebDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ParkingReservation>> GetExpiredReservationsAsync(DateTime currentTime)
        {
            return await _dbContext.ParkingReservations
                .Where(pr => pr.DepartureTime <= currentTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<ParkingReservation>> GetConflictingReservationsAsync(int parkingSpotId, DateTime? arrivalTime, DateTime? departureTime)
        {
            return await _dbContext.ParkingReservations
                .Where(r => r.ParkingSpotId == parkingSpotId && 
                            r.ArrivalTime < departureTime &&
                            r.DepartureTime > arrivalTime)
                .ToListAsync();
        }
    }
}
