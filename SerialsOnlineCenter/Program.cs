using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SerialsOnlineCenter.Converters;
using SerialsOnlineCenter.DAL;
using SerialsOnlineCenter.Extensions;
using SerialsOnlineService.BLL;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
}); ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(options => options.MapType<DateOnly>(() => new OpenApiSchema
{
    Type = "string",
    Format = "date",
    Example = new OpenApiString("2022-01-01")
}));

builder.Services.RegisterDataAccessDependencies(configuration);
builder.Services.RegisterBusinessLogicDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.InitializeDatabase();

app.Run();