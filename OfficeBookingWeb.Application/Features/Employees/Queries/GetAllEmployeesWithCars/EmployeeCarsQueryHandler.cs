using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployeesWithCars
{
    public class EmployeeCarsQueryHandler : IRequestHandler<EmployeeCarsListQuery, List<EmployeeCarsListVm>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeCarsQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeCarsListVm>> Handle(EmployeeCarsListQuery request, CancellationToken cancellationToken)
        {
            var employeeCars = await _employeeRepository.GetEmployeesWithCars();

            var employeeCarsList = employeeCars.SelectMany(e => e.Cars.Select(c => new EmployeeCarsListVm
            {
                FullName = e.FullName,
                CarBrand = c.CarBrand,
                RegisterNumber = c.RegisterNumber
            }).ToList());
            return _mapper.Map<List<EmployeeCarsListVm>>(employeeCarsList);
           
        }
    }
}
