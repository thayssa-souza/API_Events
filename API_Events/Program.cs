using API_Events.Core.Interfaces;
using API_Events.Core.Interfaces.IEvents;
using API_Events.Core.Interfaces.IRepository;
using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Services;
using API_Events.Filters;
using API_Events.Infra.Data;
using API_Events.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConnectionDataBase, ConnectionDataBase>();
builder.Services.AddScoped<ICityEventRepository, CityEventRepository>();
builder.Services.AddScoped<ICityEventService, CityEventService>();
builder.Services.AddScoped<IEventReservationRepository, EventReservationRepository>();
builder.Services.AddScoped<IEventReservationService, EventReservationService>();
builder.Services.AddScoped<ValidateExistEventActionFilter>();
builder.Services.AddScoped<ValidateExistReservationActionFilter>();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<GeneralExceptionFilters>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
