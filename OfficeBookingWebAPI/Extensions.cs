using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OfficeBookingWeb.Application;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Persistence;
using OfficeBookingWeb.Persistence.Repositories;

namespace OfficeBookingWebAPI
{
    public static class Extensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Configuration.GetConnectionString("TestDB");

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });


            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Office Booking API", Version = "v1" });
            });

            return builder.Build();
        }

        public static WebApplication ConfigureApp(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Office Booking API v1");
                    c.RoutePrefix = string.Empty;
                });
            }


            app.UseCors(options => 
                options.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.MapControllers();

            return app;
        }
       
    }
}
