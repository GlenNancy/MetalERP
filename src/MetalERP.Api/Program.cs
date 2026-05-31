using MetalERP.Application;
using MetalERP.Application.Contracts;
using MetalERP.Infrastructure.Persistence;
using MetalERP.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using MetalERP.Infrastructure;
using MetalERP.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddApplication();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapSetorEndpoints();

app.Run();