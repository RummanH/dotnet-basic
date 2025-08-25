
using Doctors.Data;
using Microsoft.EntityFrameworkCore;
using Doctors.Middlewares;
using Doctors.Services;
using Doctors.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DoctorsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository (Scoped)
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

// Service (Scoped)
builder.Services.AddScoped<DoctorService>();




builder.Services.AddControllers();



var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
