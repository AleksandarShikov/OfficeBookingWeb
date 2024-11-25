﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployeesWithCars
{
    public class EmployeeCarsListQuery : IRequest<List<EmployeeCarsListVm>>
    {
    }
}
