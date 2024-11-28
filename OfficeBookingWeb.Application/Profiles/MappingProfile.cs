using System;
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

namespace OfficeBookingWeb.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OfficePresence, OfficePresenceListVm>().ReverseMap();
            CreateMap<OfficePresence, CreateOfficePresenceCommand>().ReverseMap();

            CreateMap<Employee, EmployeeListVm>().ReverseMap();
            CreateMap<Employee, EmployeeCarsListVm>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();

            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, CarDTO>().ReverseMap();

            CreateMap<ParkingReservation, CreateParkingReservationCommand>().ReverseMap();

        }
    }
}
