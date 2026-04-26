using MachineIntegration.Interfaces;
using MachineIntegration.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddSingleton<IMachineEventService, EventService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();