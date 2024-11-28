using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;

namespace OfficeBookingWeb.Application.Features.OfficeRooms.Queries
{
    public class GetOfficeRoomListQueryHandler : IRequestHandler<GetOfficeRoomListQuery, List<OfficeRoomListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IOfficeRoomRepository _officeRoomRepository;
        public GetOfficeRoomListQueryHandler(IMapper mapper, IOfficeRoomRepository officeRoomRepository)
        {
            _mapper = mapper;
            _officeRoomRepository = officeRoomRepository;
        }

        public async Task<List<OfficeRoomListVm>> Handle(GetOfficeRoomListQuery request, CancellationToken cancellationToken)
        {
            var officeRooms = await _officeRoomRepository.ListAllAsync();
            return _mapper.Map<List<OfficeRoomListVm>>(officeRooms);
        }
    }
}
