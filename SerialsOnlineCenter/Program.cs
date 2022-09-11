using FluentMigrator.Runner;
using SerialsOnlineCenter.DAL;
using SerialsOnlineCenter.DAL.Interfaces;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DataAccessDI.RegisterDataAccessDependencies(builder.Services, configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();

var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
var dbCreator = scope.ServiceProvider.GetService<IDatabaseCreator>();

dbCreator.CreateDatabase("serials");
migrator.MigrateUp();

app.Run();