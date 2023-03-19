using Company.Delivery.Api.AppStart;
using Company.Delivery.Database;
using Microsoft.EntityFrameworkCore;
using Company.Delivery.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDeliveryControllers();
builder.Services.AddDeliveryApi();
builder.Services.AddDbContext<DeliveryDbContext>
    (o => o.UseInMemoryDatabase("DeliveryDatabase"));
var app = builder.Build();
app.UseDeliveryApi();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();