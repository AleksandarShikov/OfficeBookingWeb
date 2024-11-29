using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Queries.GetOfficePresence
{
    public class GetOfficePresenceDetailsListQuery : IRequest<List<OfficePresenceDetailsListVm>>
    {

    }
}
