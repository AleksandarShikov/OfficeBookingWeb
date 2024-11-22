using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;

public class GetOfficePresenceListQueryHandler : IRequestHandler<GetOfficePresenceListQuery, List<OfficePresenceListVm>>
{
    private readonly IAsyncRepository<OfficePresence> _officePresenceRepository;
    private readonly IMapper _mapper;

    public GetOfficePresenceListQueryHandler(IMapper mapper, IAsyncRepository<OfficePresence> officePresenceRepository)
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