using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OfficeBookingWeb.Domain.Common;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Persistence
{
    public class OfficeBookingWebDbContext : DbContext
    {
        public OfficeBookingWebDbContext(DbContextOptions<OfficeBookingWebDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<OfficePresence> OfficePresence { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OfficeRoom> OfficeRooms { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entity in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entity.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}



