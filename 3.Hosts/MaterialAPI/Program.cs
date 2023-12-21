using Application.Catalog.STA0010_Material_Masters;
using Application.Catalog.STA0020_Material_Supplier_LOTNOs;
using Application.Catalog.STA0030_Material_Supplier_RAWNOs;
using Application.Catalog.STA1010_Material_IN_OUT_Logs;
using Application.Catalog.STB0010_BARCODE_Printing_Logs;
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

builder.Services.AddScoped<ISTA0010_Material_MasterService, STA0010_Material_MasterService>();
builder.Services.AddScoped<ISTA0020_Material_Supplier_LOTNOService, STA0020_Material_Supplier_LOTNOService>();
builder.Services.AddScoped<ISTA0030_Material_Supplier_RAWNOService, STA0030_Material_Supplier_RAWNOService>();
builder.Services.AddScoped<ISTA1010_Material_IN_OUT_LogService, STA1010_Material_IN_OUT_LogService>();

builder.Services.AddScoped<ISTB0010_BARCODE_Printing_LogService, STB0010_BARCODE_Printing_LogService>();

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
