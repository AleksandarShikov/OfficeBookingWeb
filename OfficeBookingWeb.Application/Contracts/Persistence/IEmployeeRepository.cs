using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Contracts.Persistence;

public interface IEmployeeRepository : IAsyncRepository<Employee>
{
    
}