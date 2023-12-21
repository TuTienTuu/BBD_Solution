using Application.Catalog.Glues;
using Application.Catalog.Materials;
using Application.Catalog.MaterialTypes;
using Application.Catalog.Papers;
using Application.Catalog.PaperTypeMains;
using Application.Catalog.PaperTypes;
using Application.Catalog.Soles;
using Application.Catalog.UpdateDataPaperTrackings;
using Application.System.Users;
using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Utilities.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
builder.Services.AddScoped<IGlueService, GlueService>();
builder.Services.AddScoped<ISoleService, SoleService>();
builder.Services.AddScoped<IPaperTypeService, PaperTypeService>();
builder.Services.AddScoped<IPaperTypeMainService, PaperTypeMainService>();
builder.Services.AddScoped<IPaperService, PaperService>();
builder.Services.AddScoped<IUpdateDataPaperTrackingService, UpdateDataPaperTrackingService>();

builder.Services.AddScoped<IMaterialTypeService, MaterialTypeService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();

builder.Services.AddScoped<UserManager<Employee>, UserManager<Employee>>();
builder.Services.AddScoped<SignInManager<Employee>, SignInManager<Employee>>();
builder.Services.AddScoped<RoleManager<EmployeeRole>, RoleManager<EmployeeRole>>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication();
builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Paper API", Version = "v1" });
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
