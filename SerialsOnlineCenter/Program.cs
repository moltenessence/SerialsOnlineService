using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SerialsOnlineCenter.Converters;
using SerialsOnlineCenter.Extensions;
using SerialsOnlineCenter.Middelwares;
using SerialsOnlineService.BLL;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(options => options.MapType<DateOnly>(() => new OpenApiSchema
{
    Type = "string",
    Format = "date",
    Example = new OpenApiString("2022-01-01")
}));

builder.Services.RegisterBusinessLogicDependencies(configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.InitializeDatabase();

app.Run();