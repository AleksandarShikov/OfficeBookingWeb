using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Application.Features.Employees.DTOs;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeListVm>>
    {
        public IAsyncRepository<Employee> _employeeRepository;
        public IMapper _mapper;

        public GetEmployeeQueryHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeListVm>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var allEmployees = (await _employeeRepository.ListAllAsync()).OrderBy(e => e);

            return _mapper.Map<List<EmployeeListVm>>(allEmployees);
        }
    }
}
