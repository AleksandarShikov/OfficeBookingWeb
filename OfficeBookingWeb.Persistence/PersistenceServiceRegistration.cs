using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Application.Features.OfficePresences.Commands;
using OfficeBookingWeb.Application.Features.ParkingReservations.Command;
using OfficeBookingWeb.Persistence.Repositories;

namespace OfficeBookingWeb.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OfficeBookingWebDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TestDb")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOfficePresenceRepository, OfficePresenceRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IParkingReservationRepository, ParkingReservationRepository>();
            services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();
            services.AddScoped<IOfficeRoomRepository, OfficeRoomRepository>();
            services.AddTransient<ParkingReservationValidators>();
            services.AddTransient<OfficePresenceValidators>();

            return services;
        }
    }
}
