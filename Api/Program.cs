using Data;
using Data.Contracts;
using Data.Contracts.UserSchema;
using Microsoft.EntityFrameworkCore;
using Services.DataServices;
using Services.DataServices.UserSchema;
using WebFramework.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//builder.Services.AddScoped(typeof(IService), typeof(Service));
builder.Services.AddScoped(typeof(IUserService),typeof(UserService));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});


var app = builder.Build();

app.UseCustomExceptionHandler();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
