using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeBookingWeb.Application.Contracts.Persistence;

namespace OfficeBookingWeb.Application.Features.OfficePresences.Commands
{
    public class OfficePresenceValidators
    {
        private readonly IOfficePresenceRepository _officePresenceRepository;

        public OfficePresenceValidators(IOfficePresenceRepository officePresenceRepository)
        {
            _officePresenceRepository = officePresenceRepository;
        }

        public async Task CleanUpExpiredPresences()
        {
            var now = DateOnly.FromDateTime(DateTime.Now);

            var expiredPresences = await _officePresenceRepository.GetExpiredPresences(now);

            foreach (var presence in expiredPresences)
            {
                await _officePresenceRepository.SoftDeleteAsync(presence);
            }
        }
    }
}
