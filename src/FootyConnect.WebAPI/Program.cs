using FootyConnect.Application;
using FootyConnect.Infrastructure;
using FootyConnect.Infrastructure.ConfigurationOptions;
using FootyConnect.Persistence;
using FootyConnect.WebAPI;
using FootyConnect.WebAPI.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

var appSettings = configuration.Get<AppSettings>()!;

services.Configure<AppSettings>(configuration);

services.AddControllers();

services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

services.AddPersistence(appSettings.ConnectionStrings.FootyConnectDb);

services.AddInfrastructure();

services.AddHandlers();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

services.ConfigureOptions<JwtBearerOptionsSetup>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
