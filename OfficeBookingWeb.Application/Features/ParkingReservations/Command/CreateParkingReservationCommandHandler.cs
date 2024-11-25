using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;


namespace OfficeBookingWeb.Application.Features.ParkingReservations.Command
{
    public class CreateParkingReservationCommandHandler : IRequestHandler<CreateParkingReservationCommand, bool>
    {
        private readonly IParkingReservationRepository _parkingReservationRepository;
        private readonly IParkingSpotRepository _parkingSpotRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ParkingReservationValidators _parkingReservationValidators;

        public CreateParkingReservationCommandHandler(
            IParkingReservationRepository parkingReservationRepository,
            IParkingSpotRepository parkingSpotRepository,
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            ParkingReservationValidators parkingReservationValidators)
        {
            _parkingReservationRepository = parkingReservationRepository;
            _parkingSpotRepository = parkingSpotRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _parkingReservationValidators = parkingReservationValidators;
        }

        public async Task<bool> Handle(CreateParkingReservationCommand request, CancellationToken cancellationToken)
        {
            await _parkingReservationValidators.CleanUpExpiredReservationsAsync();

            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            var parkingSpot = await _parkingSpotRepository.GetByIdAsync(request.ParkingSpotId);
            if (parkingSpot == null)
            {
                throw new Exception("Parking spot not found.");
            }

            if (parkingSpot.IsReserved)
            {
                throw new Exception("Parking spot is already reserved.");
            }

            var conflictingReservations = await _parkingReservationValidators.HasConflictingReservationAsync(request.ParkingSpotId, request.ArrivalTime, request.DepartureTime);
            if (conflictingReservations)
            {
                throw new Exception("Parking spot is already reserved for the selected time range.");
            }

            var parkingReservation = _mapper.Map<ParkingReservation>(request);

            parkingSpot.IsReserved = true;
            await _parkingSpotRepository.UpdateAsync(parkingSpot);

            await _parkingReservationRepository.AddAsync(parkingReservation);

            return true;
        }
    }
}
        }
    }
}
