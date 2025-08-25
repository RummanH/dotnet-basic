using Doctors.Middlewares;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddSingleton<Doctors.Repositories.DoctorRepository>();
builder.Services.AddSingleton<Doctors.Services.DoctorService>();

var app = builder.Build();



app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
