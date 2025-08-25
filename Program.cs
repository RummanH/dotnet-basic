
using Doctors.Data;
using Microsoft.EntityFrameworkCore;
using Doctors.Middlewares;
using Doctors.Services;
using Doctors.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DoctorsDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
  {
    Title = "Doctors API",
    Version = "v1",
    Description = "A simple API to manage doctors"
  });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
