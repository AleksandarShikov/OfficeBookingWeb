using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeBookingWeb.Application.Features.Cars.Command
{
    public class CreateCarCommand : IRequest<int>
    {

        public int EmployeeId { get; set; }

        public string CarBrand { get; set; } = null!;

        public string RegisterNumber { get; set; } = null!;
    }
}
