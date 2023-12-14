using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using BasicWebAPI;
using BasicWebAPI.Repository.Interfaces;
using BasicWebAPI.Service.Interfaces;
using System;
using BasicWebAPI.Services;
using BasicWebAPI.Repositories;
using BasicWebAPI.Data;
using Microsoft.Extensions.Hosting;


var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;



// Add services to the container.
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

//repositories

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c=> c.AddPolicy("BasicWebAPICorsPolicy", builder =>
{
    builder
    //.WithOrigins()
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod();
}));

builder.Services.AddDbContext<BasicWebApiDbContext>(options =>
{
    if (environment.EnvironmentName.Equals("Production"))
    {
        options.UseSqlServer(configuration.GetValue<string>("Configuration:ConnectionStringProd"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        });
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    }
    else
    {
        options.UseSqlServer(configuration.GetValue<string>("Configuration:ConnectionString"),
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            });
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
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
