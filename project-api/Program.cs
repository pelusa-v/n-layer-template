using project_api.DataAccess;
using project_api.Application;
using project_api.API;
using System.Text.Json.Serialization;
using project_api;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseSentry();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ignore cycles
builder.Services.AddControllers()
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddDataAccessLayer(builder.Configuration)
    .AddApplicationLayer(builder.Configuration)
    .AddAPILayer(builder.Configuration);

var app = builder.Build();

// Seed data
using (var serviceScope = app.Services.CreateScope())
{
    SeedPets.Initialize(serviceScope.ServiceProvider, builder.Configuration);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS
app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    );

app.MapControllers();

app.Run();