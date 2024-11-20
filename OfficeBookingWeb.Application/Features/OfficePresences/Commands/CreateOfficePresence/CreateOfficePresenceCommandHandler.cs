using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands.CreateOfficePresence
{
    public class CreateOfficePresenceCommandHandler : IRequestHandler<CreateOfficePresenceCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly IOfficePresenceRepository _officePresenceRepository;

        public CreateOfficePresenceCommandHandler(IMapper mapper, IOfficePresenceRepository officePresence)
        {
            this._mapper = mapper;
            _officePresenceRepository = officePresence;
        }
        public async Task<int> Handle(CreateOfficePresenceCommand request, CancellationToken cancellationToken)
        {
            var officePresence = _mapper.Map<OfficePresence>(request);
            var createdOfficePresence = await _officePresenceRepository.AddAsync(officePresence);

            return createdOfficePresence.PresenceId;
        }
    }
}
