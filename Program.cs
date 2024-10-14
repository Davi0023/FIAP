#region IMPORTAÇÃO REFERENTE AO BANCO DE DADOS
using AutoMapper;
using Fiap.Web.Challenge.Data.Contexts;
using Fiap.Web.Challenge.Data.Repository;
using Fiap.Web.Challenge.Logging;
using Fiap.Web.Challenge.Models;
using Fiap.Web.Challenge.Models.ViewModels;
using Fiap.Web.Challenge.Services;
using Microsoft.EntityFrameworkCore;
#endregion


var builder = WebApplication.CreateBuilder(args);

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion


#region Registro IserviceCollection
builder.Services.AddSingleton<ICustomLogger, FileLogger>();

builder.Services.AddScoped<ISensoresRepository, SensoresRepository>();
builder.Services.AddScoped<ILocalRepository, LocalRepository>();

builder.Services.AddScoped<ISensoresService, SensoresService>();
builder.Services.AddScoped<ILocalService, LocalService>();


#endregion


#region AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<SensoresModel, SensoresCadastroViewModel>();
    c.CreateMap<SensoresCadastroViewModel, SensoresModel>();

});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

