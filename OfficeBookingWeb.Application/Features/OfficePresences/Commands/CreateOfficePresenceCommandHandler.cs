using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Application.Features.ParkingReservations.Command;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands
{
    public class CreateOfficePresenceCommandHandler : IRequestHandler<CreateOfficePresenceCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IOfficePresenceRepository _officePresenceRepositoryRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOfficeRoomRepository _officeRoomRepository;
        private readonly IParkingReservationRepository _parkingReservationRepository;
        private readonly OfficePresenceValidators _officePresenceValidators;
        private readonly ParkingReservationValidators _parkingReservationValidators;

        public CreateOfficePresenceCommandHandler(IMapper mapper, IOfficePresenceRepository officePresenceRepository,
            IOfficeRoomRepository officeRoomRepository, IEmployeeRepository employeeRepository,
            IParkingReservationRepository parkingReservationRepository,OfficePresenceValidators officePresenceValidators,
            ParkingReservationValidators parkingReservationValidators)
        {
            _mapper = mapper;
            _officePresenceRepositoryRepository = officePresenceRepository;
            _employeeRepository = employeeRepository;
            _officeRoomRepository = officeRoomRepository;
            _parkingReservationRepository = parkingReservationRepository;
            _officePresenceValidators = officePresenceValidators;
            _parkingReservationValidators = parkingReservationValidators;
        }
        public async Task<int> Handle(CreateOfficePresenceCommand request, CancellationToken cancellationToken)
        {
            if (request.PresenceDate < DateOnly.FromDateTime(DateTime.Today))
            {
                throw new ArgumentException("Presence date cannot be before today.");
            }

            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with ID {request.EmployeeId} does not exist.");
            }

            var room = await _officeRoomRepository.GetByIdAsync(request.RoomId);
            if (room == null)
            {
                throw new ArgumentException($"Room with ID {request.RoomId} does not exist.");
            }

            if (request.ReservationId.HasValue)
            {
                var parkingReservation = await _parkingReservationRepository.GetByIdAsync(request.ReservationId.Value);
                if (parkingReservation == null)
                {
                    throw new ArgumentException($"Parking reservation with ID {request.ReservationId} does not exist.");
                }
                if (request.PresenceDate != DateOnly.FromDateTime(parkingReservation.ArrivalTime))
                {
                    throw new ArgumentException("Presence date must match timestamp.");
                }

                if (request.PresenceDate != DateOnly.FromDateTime(parkingReservation.DepartureTime))
                {
                    throw new ArgumentException("Presence date must match timestamp.");
                }
                if (request.EmployeeId != parkingReservation.EmployeeId)
                {
                    throw new ArgumentException($"Employee ID {request.EmployeeId} does not match the one in the parking reservation.");
                }
            }
            var officePresences = await _officePresenceRepositoryRepository.ListAllAsync(); 
            foreach (var existingPresence in officePresences)
            {
                if (existingPresence.EmployeeId == request.EmployeeId && existingPresence.PresenceDate == request.PresenceDate)
                {
                    throw new ArgumentException($"Employee {request.EmployeeId} has already registered an office presence for {request.PresenceDate}.");
                }
            }

            var officePresence = _mapper.Map<OfficePresence>(request);
            var createdOfficePresence = await _officePresenceRepositoryRepository.AddAsync(officePresence);

            await _officePresenceValidators.CleanUpExpiredPresences();
            await _parkingReservationValidators.CleanUpExpiredReservationsAsync();

            return createdOfficePresence.PresenceId;
        }
    }
}
