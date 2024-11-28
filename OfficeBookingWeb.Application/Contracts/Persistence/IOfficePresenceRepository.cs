using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Contracts.Persistence;

public interface IOfficePresenceRepository : IAsyncRepository<OfficePresence>
{
    public Task<List<OfficePresence>> GetExpiredPresences(DateOnly currentTime);
}