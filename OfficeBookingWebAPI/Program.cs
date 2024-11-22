using OfficeBookingWebAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .ConfigureServices()
    .ConfigureApp();



app.Run();
