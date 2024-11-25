using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployeesWithCars
{
    public class EmployeeCarsQueryHandler : IRequestHandler<EmployeeCarsListQuery, List<EmployeeCarsListVm>>
    {
        public IEmployeeRepository _employeeRepository;
        public IMapper _mapper;

        public EmployeeCarsQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeCarsListVm>> Handle(EmployeeCarsListQuery request, CancellationToken cancellationToken)
        {
            var employeeCars = (await _employeeRepository.GetEmployeesWithCars()).OrderBy(e => e);
            return _mapper.Map<List<EmployeeCarsListVm>>(employeeCars);
        }
    }
}
