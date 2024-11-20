using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands.CreateOfficePresence;
using OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands.CreateOfficePresence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OfficePresence, OfficePresenceListVm>().ReverseMap();
            CreateMap<OfficePresence, CreateOfficePresenceCommand>().ReverseMap();
        }
    }
}
