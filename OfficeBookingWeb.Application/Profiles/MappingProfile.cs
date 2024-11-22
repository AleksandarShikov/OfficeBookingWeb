﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands.CreateOfficePresence;
using OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands.CreateOfficePresence;
using OfficeBookingWeb.Domain.Entities;
using OfficeBookingWeb.Application.Features.Employees.DTOs;

namespace OfficeBookingWeb.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OfficePresence, OfficePresenceListVm>().ReverseMap();
            CreateMap<OfficePresence, CreateOfficePresenceCommand>().ReverseMap();

            CreateMap<Employee, EmployeeListVm>().ReverseMap();
            CreateMap<Employee, CreateOfficePresenceCommand>().ReverseMap();

            CreateMap<Employee, EmployeeCarsListVm>().ReverseMap();

            CreateMap<Car, CarDTO>().ReverseMap();

        }
    }
}
