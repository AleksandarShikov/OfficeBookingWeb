using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;

namespace OfficeBookingWeb.Application.Features.Employees.Command
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this._mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee =  await _employeeRepository.GetByIdAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            await _employeeRepository.SoftDeleteAsync(employee);
            return true;
        }
    }
}
