using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands
{
    public class DeleteOfficePresenceCommandHandler : IRequestHandler<DeleteOfficePresenceCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOfficePresenceRepository _officePresenceRepository;
        private readonly OfficePresenceValidators _officePresenceValidators;

        public DeleteOfficePresenceCommandHandler(IMapper mapper, IOfficePresenceRepository officePresenceRepository, 
            OfficePresenceValidators officePresenceValidators)
        {
            _mapper = mapper;
            _officePresenceRepository = officePresenceRepository;
            _officePresenceValidators = officePresenceValidators;
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

            return true;
        }
    }
}
