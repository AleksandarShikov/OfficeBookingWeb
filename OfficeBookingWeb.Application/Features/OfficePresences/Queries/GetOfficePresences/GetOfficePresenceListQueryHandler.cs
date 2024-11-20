using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;

public class GetOfficePresenceListQueryHandler : IRequestHandler<GetOfficePresenceListQuery, List<OfficePresenceListVm>>
{
    private readonly IAsyncRepository<Domain.Entities.OfficePresence> _officePresenceRepository;
    private readonly IMapper _mapper;

    public GetOfficePresenceListQueryHandler(Mapper mapper, IAsyncRepository<Domain.Entities.OfficePresence> officePresenceRepository)
    {
        _mapper = mapper;
        _officePresenceRepository = officePresenceRepository;
    }

    public async Task<List<OfficePresenceListVm>> Handle(GetOfficePresenceListQuery request, CancellationToken cancellationToken)
    {
        var allOfficePresences = (await _officePresenceRepository.ListAllAsync()).OrderBy(o => o.PresenceDate);

        return _mapper.Map<List<OfficePresenceListVm>>(allOfficePresences);
    }
}