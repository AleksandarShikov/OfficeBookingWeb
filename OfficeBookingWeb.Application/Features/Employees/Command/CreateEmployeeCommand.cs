using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.Employees.Command
{
    public class CreateEmployeeCommand : IRequest<int>
    {

        public string FullName { get; set; }

        public int DepartmentId { get; set; }

    }
}
