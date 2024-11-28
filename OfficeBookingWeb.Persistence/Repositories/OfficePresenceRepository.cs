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
    public class OfficePresenceRepository : BaseRepository<OfficePresence>, IOfficePresenceRepository
    {
        public OfficePresenceRepository(OfficeBookingWebDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<OfficePresence>> GetExpiredPresences(DateOnly currentTime)
        {
            return await _dbContext.OfficePresence
                .Where(p=>p.PresenceDate < currentTime)
                .ToListAsync();
        }
    }
}
