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
    public partial class OfficeBookingWebDbContext : DbContext
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarId).HasName("PK__Cars__68A0342E5FF66CA3");

                entity.HasIndex(e => e.RegisterNumber, "UQ__Cars__86F493318617D01C").IsUnique();

                entity.Property(e => e.CarBrand)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RegisterNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cars__EmployeeId__4BAC3F29");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED3F6A7F34");

                entity.HasIndex(e => e.DepartmentName, "UQ__Departme__D949CC3419D2E07B").IsUnique();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F118BDC3EC6");

                entity.HasIndex(e => e.FullName, "UQ__Employee__89C60F11469DF1C5").IsUnique();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Depar__3D5E1FD2");
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<OfficePresence>(entity =>
            {
                entity.HasKey(e => e.PresenceId).HasName("PK__OfficePr__4980E86367702CCE");

                entity.ToTable("OfficePresence");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Notes)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee).WithMany(p => p.OfficePresences)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OfficePre__Emplo__59063A47");

                entity.HasOne(d => d.Reservation).WithMany(p => p.OfficePresences)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK__OfficePre__Reser__59FA5E80");

                entity.HasOne(d => d.Room).WithMany(p => p.OfficePresences)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OfficePre__RoomI__5AEE82B9");
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<OfficeRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId).HasName("PK__OfficeRo__32863939D6F26176");

                entity.HasIndex(e => e.RoomNumber, "UQ__OfficeRo__AE10E07A193999E6").IsUnique();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<ParkingReservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId).HasName("PK__ParkingR__B7EE5F24D2A68F3C");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Employee).WithMany(p => p.ParkingReservations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ParkingRe__Emplo__5535A963");

                entity.HasOne(d => d.ParkingSpot).WithMany(p => p.ParkingReservations)
                    .HasForeignKey(d => d.ParkingSpotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ParkingRe__Parki__5629CD9C");
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<ParkingSpot>(entity =>
            {
                entity.HasKey(e => e.ParkingSpotId).HasName("PK__ParkingS__FE67E7DC60393D85");

                entity.HasIndex(e => e.SpotNumber, "UQ__ParkingS__0FD4FFA1EAE9D9CE").IsUnique();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.HasQueryFilter(e => !e.IsDeleted);

            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}



