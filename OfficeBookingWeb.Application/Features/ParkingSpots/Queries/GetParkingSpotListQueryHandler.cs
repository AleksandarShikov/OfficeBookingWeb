using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.ParkingSpots.Queries
{
    public class GetParkingSpotListQueryHandler : IRequestHandler<GetParkingSpotListQuery, List<ParkingSpotListVm>>
    {
        private readonly IParkingSpotRepository _parkingSpotRepository;
        private readonly IMapper _mapper;

        public GetParkingSpotListQueryHandler(IMapper mapper, IParkingSpotRepository parkingSpotRepository)
        {
            _mapper = mapper;
            _parkingSpotRepository = parkingSpotRepository;
        }

        public async Task<List<ParkingSpotListVm>> Handle(GetParkingSpotListQuery request, CancellationToken cancellationToken)
        {
            var spots = await _parkingSpotRepository.ListAllAsync();
            return _mapper.Map<List<ParkingSpotListVm>>(spots);
        }
    }
}
