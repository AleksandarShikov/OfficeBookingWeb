using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Application.Features.ParkingReservations.Command;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands
{
    public class DeleteOfficePresenceCommandHandler : IRequestHandler<DeleteOfficePresenceCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOfficePresenceRepository _officePresenceRepository;
        private readonly OfficePresenceValidators _officePresenceValidators;
        private readonly ParkingReservationValidators _parkingReservationValidators;

        public DeleteOfficePresenceCommandHandler(IMapper mapper, IOfficePresenceRepository officePresenceRepository, 
            OfficePresenceValidators officePresenceValidators, ParkingReservationValidators parkingReservationValidators)
        {
            _mapper = mapper;
            _officePresenceRepository = officePresenceRepository;
            _officePresenceValidators = officePresenceValidators;
            _parkingReservationValidators = parkingReservationValidators;
        }

        public async Task<bool> Handle(DeleteOfficePresenceCommand request, CancellationToken cancellationToken)
        {
            var officePresence = await _officePresenceRepository.GetByIdAsync(request.PresenceId);
            if (officePresence == null)
            {
                throw new ArgumentException("Office presence record not found");
            }

            await _officePresenceRepository.SoftDeleteAsync(officePresence);
            await _officePresenceValidators.CleanUpExpiredPresences();
            await _parkingReservationValidators.CleanUpExpiredReservationsAsync();

            return true;
        }
    }
}
