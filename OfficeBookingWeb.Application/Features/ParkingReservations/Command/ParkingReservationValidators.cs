using OfficeBookingWeb.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.ParkingReservations.Command
{
    public class ParkingReservationValidators
    {
        private readonly IParkingReservationRepository _parkingReservationRepository;
        private readonly IParkingSpotRepository _parkingSpotRepository;
        public async Task CleanUpExpiredReservationsAsync()
        {

            var now = DateTime.Now;

            var expiredReservations = await _parkingReservationRepository.GetExpiredReservationsAsync(now);

            foreach (var reservation in expiredReservations)
            {
                var parkingSpot = await _parkingSpotRepository.GetByIdAsync(reservation.ParkingSpotId);
                if (parkingSpot != null)
                {
                    parkingSpot.IsReserved = false;
                    await _parkingSpotRepository.UpdateAsync(parkingSpot);
                }
                await _parkingReservationRepository.DeleteAsync(reservation);
            }
        }
        public async Task<bool> HasConflictingReservationAsync(int parkingSpotId, DateTime arrivalTime, DateTime departureTime)
        {
            var conflictingReservations = await _parkingReservationRepository.GetConflictingReservationsAsync(parkingSpotId, arrivalTime, departureTime);
            return conflictingReservations.Any();
        }

    }
}
