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
        private readonly IEmployeeRepository _employeeRepository;

        public ParkingReservationValidators(IParkingReservationRepository parkingReservationRepository, IEmployeeRepository employeeRepository)
        {
            _parkingReservationRepository = parkingReservationRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> HasConflictingReservationAsync(int parkingSpotId, DateTime? arrivalTime, DateTime? departureTime)
        {
            if (!arrivalTime.HasValue || !departureTime.HasValue)
                throw new ArgumentException("Arrival and Departure times cannot be null");
            if (arrivalTime >= departureTime)
                throw new ArgumentException("Arrival time should be earlier than departure time");

            var conflictingReservations = await _parkingReservationRepository.GetConflictingReservationsAsync(parkingSpotId, arrivalTime, departureTime);

            return conflictingReservations.Any();
        }
        public async Task CleanUpExpiredReservationsAsync()
        {
            var now = DateTime.Now;


            var expiredReservations = await _parkingReservationRepository.GetExpiredReservationsAsync(now);

            foreach (var reservation in expiredReservations)
            {
                await _parkingReservationRepository.SoftDeleteAsync(reservation);
            }
        }
        public async Task ValidateEmployeeCarAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetQueryable()
                .Include(e => e.Cars) 
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee == null || !employee.Cars.Any())
            {
                throw new ArgumentException("The employee does not have a car and cannot reserve a parking spot.");
            }
        }

    }
}
