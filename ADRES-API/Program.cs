using ADRES_API.DAOs;
using ADRES_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Build configuration
var configuration = builder.Configuration;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/postPresupuesto",  (PresupuestoDTO data) =>
{
    try
    {
        var dao = new DAO(configuration);
        return dao.SavePresupuestos(data);
    }
    catch (Exception e)
    {
        throw e;
    }
});
app.MapGet("/getcredenciales", () =>
{
    try
    {
        var dao = new DAO(configuration);
        return dao.GetPresupuestos();
    }
    catch (Exception e)
    {
        throw e;
    }
});
app.MapPost("/Authentication", (Login user) =>
{
    try
    {
        var dao = new DAO(configuration);
        return dao.GetLogins(user);
    }
    catch (Exception e)
    {
        return 0;
    } 
});
app.MapPut("/UpdateStatus", (int Id) =>
{
    try
    {
        var dao = new DAO(configuration);
        return dao.UpadateStatus(Id);
    }
    catch (Exception e)
    {
        return 0;
    }
});
app.MapDelete("/DeletePresupueto", (int Id) =>
{
    try
    {
        var dao = new DAO(configuration);
        return dao.DeletePresupueto(Id);
    }
    catch (Exception e)
    {
        return 0;
    }
});


app.Run();
