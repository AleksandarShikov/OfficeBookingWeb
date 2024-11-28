using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;

public class GetOfficePresenceListQueryHandler : IRequestHandler<GetOfficePresenceListQuery, List<OfficePresenceListVm>>
{
    private readonly IOfficePresenceRepository _officePresenceRepository;
    private readonly IMapper _mapper;
    private readonly OfficePresenceValidators _officePresenceValidators;

    public GetOfficePresenceListQueryHandler(IMapper mapper, IOfficePresenceRepository officePresenceRepository,
        OfficePresenceValidators officePresenceValidators)
    {
        _mapper = mapper;
        _officePresenceRepository = officePresenceRepository;
        _officePresenceValidators = officePresenceValidators;
    }

    public async Task<List<OfficePresenceListVm>> Handle(GetOfficePresenceListQuery request, CancellationToken cancellationToken)
    {
        await _officePresenceValidators.CleanUpExpiredPresences();
        var allOfficePresences = await _officePresenceRepository.GetQueryable()
            .Include(op => op.Employee)
            .Include(op => op.Employee.Department)
            .Include(op => op.Room) 
            .Include(op => op.ParkingReservation)
            .ThenInclude(pr => pr.ParkingSpot) 
            .OrderBy(o => o.PresenceDate)
            .ToListAsync(cancellationToken);

        var officePresenceList = allOfficePresences.Select(op => new OfficePresenceListVm
        {
            PresenceDate = op.PresenceDate,
            EmployeeFullName = op.Employee.FullName,
            EmployeeDepartment = op.Employee.Department.DepartmentName,
            RoomNumber = op.Room.RoomNumber,
            ArrivalTime = op.ParkingReservation.ArrivalTime,
            DepartureTime = op.ParkingReservation.DepartureTime,
            ParkingSpot = op.ParkingReservation.ParkingSpot.SpotNumber,
            Notes = op.Notes
        }).ToList();


        return _mapper.Map<List<OfficePresenceListVm>>(officePresenceList);
    }
}