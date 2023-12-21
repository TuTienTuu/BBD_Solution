
using ApiIntergration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
var mvcBuilder = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}
//builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IGlueApiClient, GlueApiClient>();
builder.Services.AddScoped<ISoleApiClient, SoleApiClient>();
builder.Services.AddScoped<IPaperTypeApiClient, PaperTypeApiClient>();
builder.Services.AddScoped<IPaperTypeMainApiClient, PaperTypeMainApiClient>();
builder.Services.AddScoped<IPaperApiClient, PaperApiClient>();
builder.Services.AddScoped<IDataTrackingApiClient, DataTrackingApiClient>();

builder.Services.AddScoped<IUnitPriceApiClient, UnitPriceApiClient>();

builder.Services.AddScoped<IMaterialTypeApiClient, MaterialTypeApiClient>();
builder.Services.AddScoped<IMaterialApiClient, MaterialApiClient>();

builder.Services.AddScoped<ICodeLevel1ManagementApiClient, CodeLevel1ManagementApiClient>();
builder.Services.AddScoped<ICodeLevel2ManagementApiClient, CodeLevel2ManagementApiClient>();

builder.Services.AddScoped<ISTA0010MaterialMasterApiClient, STA0010MaterialMasterApiClient>();
builder.Services.AddScoped<ISTA0020MaterialSupplierApiClient, STA0020MaterialSupplierApiClient>();
builder.Services.AddScoped<ISTA0030_Material_Supplier_RAWNOApiClient, STA0030_Material_Supplier_RAWNOApiClient>();
builder.Services.AddScoped<ISTA1010_Material_IN_OUT_LogApiClient, STA1010_Material_IN_OUT_LogApiClient>();

builder.Services.AddScoped<ISTB0010_BARCODE_Printing_LogApiClient, STB0010_BARCODE_Printing_LogApiClient>();

builder.Services.AddScoped<IMachineConfigApiClient, MachineConfigApiClient>();
builder.Services.AddScoped<IConfigFeeApiClient, ConfigFeeApiClient>();

var app = builder.Build();
 


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
