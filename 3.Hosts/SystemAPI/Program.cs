using Application.Catalog.CodeLevel1Managements;
using Application.Catalog.CodeLevel2Managements;
using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Utilities.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(SystmConstants.MainConnectionString));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

builder.Services.AddIdentity<Employee, EmployeeRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

//Decalare DI

builder.Services.AddScoped<ICodeLevel1ManagementService, CodeLevel1ManagementService>();
builder.Services.AddScoped<ICodeLevel2ManagementService, CodeLevel2ManagementService>();

builder.Services.AddScoped<UserManager<Employee>, UserManager<Employee>>();
builder.Services.AddScoped<SignInManager<Employee>, SignInManager<Employee>>();
builder.Services.AddScoped<RoleManager<EmployeeRole>, RoleManager<EmployeeRole>>();
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
