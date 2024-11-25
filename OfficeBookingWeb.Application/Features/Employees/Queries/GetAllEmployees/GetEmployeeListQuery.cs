using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetEmployeeListQuery : IRequest<List<EmployeeListVm>>
    {
    }
}
