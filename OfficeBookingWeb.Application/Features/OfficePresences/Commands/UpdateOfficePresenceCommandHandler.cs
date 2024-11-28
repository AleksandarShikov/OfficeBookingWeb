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
    public class UpdateOfficePresenceCommandHandler : IRequestHandler<UpdateOfficePresenceCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOfficePresenceRepository _officePresenceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOfficeRoomRepository _officeRoomRepository;
        private readonly IParkingReservationRepository _parkingReservationRepository;
        private readonly OfficePresenceValidators _officePresenceValidators;

        public UpdateOfficePresenceCommandHandler(IMapper mapper, IOfficePresenceRepository officePresenceRepository,
            IOfficeRoomRepository officeRoomRepository, IEmployeeRepository employeeRepository,
            IParkingReservationRepository parkingReservationRepository,OfficePresenceValidators officePresenceValidators)
        {
            _mapper = mapper;
            _officePresenceRepository = officePresenceRepository;
            _employeeRepository = employeeRepository;
            _officeRoomRepository = officeRoomRepository;
            _parkingReservationRepository = parkingReservationRepository;
            _officePresenceValidators = officePresenceValidators;
        }
        public async Task<bool> Handle(UpdateOfficePresenceCommand request, CancellationToken cancellationToken)
        {
            var officePresence = await _officePresenceRepository.GetByIdAsync(request.PresenceId);

            if (officePresence == null)
            {
                throw new ArgumentException("Presence record doesn't exist");
            }

            if (officePresence.PresenceDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("You cannot update past presence records.");
            }

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

            officePresence.PresenceDate = request.PresenceDate;
            officePresence.EmployeeId = request.EmployeeId;
            officePresence.ReservationId = request.ReservationId;
            officePresence.RoomId = request.RoomId;
            officePresence.Notes = request.Notes;

            await _officePresenceRepository.UpdateAsync(officePresence);
            await _officePresenceValidators.CleanUpExpiredPresences();
            return true;
        }
    }
}
