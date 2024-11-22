using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OfficeBookingWebDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeesWithCars()
        {
            return await _dbContext.Employees.Include(e => e.Cars).ToListAsync();
        }
    }
}
