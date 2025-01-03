﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OfficeBookingWeb.Application.Features.Cars.Command;
using OfficeBookingWeb.Application.Features.Employees.Command;
using OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;
using OfficeBookingWeb.Domain.Entities;
using OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployees;
using OfficeBookingWeb.Application.Features.DTOs;
using OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployeesWithCars;
using OfficeBookingWeb.Application.Features.ParkingReservations.Command;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands;
using OfficeBookingWeb.Application.Features.OfficeRooms.Queries;
using OfficeBookingWeb.Application.Features.ParkingSpots.Queries;

namespace OfficeBookingWeb.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OfficePresence, OfficePresenceDetailsListVm>().ReverseMap();
            CreateMap<OfficePresence, CreateOfficePresenceCommand>().ReverseMap();

            CreateMap<Employee, EmployeeListVm>().ReverseMap();
            CreateMap<Employee, EmployeeCarsListVm>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();

            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();

            CreateMap<ParkingReservation, CreateParkingReservationCommand>().ReverseMap();
            CreateMap<OfficeRoom,OfficeRoomListVm>().ReverseMap();
            CreateMap<ParkingSpot, ParkingSpotListVm>().ReverseMap();

            CreateMap<OfficePresence, CreateOfficePresenceWithReservationCommand>().ReverseMap();
            CreateMap<ParkingReservation, CreateOfficePresenceWithReservationCommand>().ReverseMap();
        }
    }
}
