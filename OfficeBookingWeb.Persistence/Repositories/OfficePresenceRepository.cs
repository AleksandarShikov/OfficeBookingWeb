using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Persistence.Repositories
{
    public class OfficePresenceRepository : BaseRepository<OfficePresence>, IOfficePresenceRepository
    {
        public OfficePresenceRepository(OfficeBookingWebDbContext dbContext) : base(dbContext)
        {
        }
    }
}
