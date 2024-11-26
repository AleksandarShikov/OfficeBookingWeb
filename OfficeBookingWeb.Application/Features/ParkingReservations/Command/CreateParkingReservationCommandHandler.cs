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
        private readonly IMapper _mapper;
        private readonly ParkingReservationValidators _parkingReservationValidators;

        public CreateParkingReservationCommandHandler(
            IParkingReservationRepository parkingReservationRepository,
            IMapper mapper,
            ParkingReservationValidators parkingReservationValidators)
        {
            _parkingReservationRepository = parkingReservationRepository;
            _mapper = mapper;
            _parkingReservationValidators = parkingReservationValidators;
        }

        public async Task<bool> Handle(CreateParkingReservationCommand request, CancellationToken cancellationToken)
        {
            await _parkingReservationValidators.CleanUpExpiredReservationsAsync();

            var hasConflict =  await _parkingReservationValidators.HasConflictingReservationAsync(request.ParkingSpotId,
                request.ArrivalTime, request.DepartureTime);

            if (hasConflict)
            {
                throw new Exception("The parking spot is already reserved for the selected time range.");
            }

            var parkingReservation = _mapper.Map<ParkingReservation>(request);
            await _parkingReservationRepository.AddAsync(parkingReservation);

            return true;
        }
    }
}
       
