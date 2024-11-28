using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands
{
    public class DeleteOfficePresenceCommand : IRequest<bool>
    {
        public int PresenceId { get; set; }
    }
}
