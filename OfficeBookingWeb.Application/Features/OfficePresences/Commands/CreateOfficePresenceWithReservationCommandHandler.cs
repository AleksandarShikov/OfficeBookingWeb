using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands
{
    public class CreateOfficePresenceWithReservationCommandHandler : IRequestHandler<CreateOfficePresenceWithReservationCommand, int>
    {
        private readonly IOfficePresenceRepository _officePresenceRepository;
        private readonly IParkingReservationRepository _parkingReservationRepository;
        private readonly IMapper _mapper;

        public CreateOfficePresenceWithReservationCommandHandler(
            IOfficePresenceRepository officePresenceRepository,
            IParkingReservationRepository parkingReservationRepository,
            IMapper mapper)
        {
            _officePresenceRepository = officePresenceRepository;
            _parkingReservationRepository = parkingReservationRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateOfficePresenceWithReservationCommand request, CancellationToken cancellationToken)
        {
            var officePresence = _mapper.Map<OfficePresence>(request);
            await _officePresenceRepository.AddAsync(officePresence);

            if (request.IsReservationRequired == true)
            {
                var parkingReservation = _mapper.Map<ParkingReservation>(request);
                await _parkingReservationRepository.AddAsync(parkingReservation);

                officePresence.ReservationId = parkingReservation.ReservationId;
                await _officePresenceRepository.UpdateAsync(officePresence);
            }

            return officePresence.PresenceId;
        }
    }
}
