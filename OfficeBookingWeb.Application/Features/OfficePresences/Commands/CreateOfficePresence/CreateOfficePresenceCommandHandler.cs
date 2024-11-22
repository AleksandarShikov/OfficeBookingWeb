using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands.CreateOfficePresence
{
    public class CreateOfficePresenceCommandHandler : IRequestHandler<CreateOfficePresenceCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly IOfficePresenceRepository _officePresenceRepositoryRepository;

        public CreateOfficePresenceCommandHandler(IMapper mapper, IOfficePresenceRepository officePresenceRepository)
        {
            this._mapper = mapper;
            _officePresenceRepositoryRepository = officePresenceRepository;
        }
        public async Task<int> Handle(CreateOfficePresenceCommand request, CancellationToken cancellationToken)
        {
            var officePresence = _mapper.Map<OfficePresence>(request);
            var createdOfficePresence = await _officePresenceRepositoryRepository.AddAsync(officePresence);

            return createdOfficePresence.PresenceId;
        }
    }
}
