﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeBookingWeb.Application.Features.Employees.Command
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int EmployeeId { get; set; }
    }
}