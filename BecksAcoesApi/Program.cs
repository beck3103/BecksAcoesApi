using Infra;
using Infra.Http.Configurations;
using Infra.Http.ExternalApiServices;
using Infra.Http.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your token here"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//Configuration Binding
builder.Services.Configure<FundamentusOptions>(builder.Configuration.GetSection("Fundamentus"));

builder.Services.RegisterAuthentication();
builder.Services.RegisterServices();

builder.Services.AddHttpClient<IFundamentusHttpClient, FundamentusHttpClient>("FundamentusClient", client =>
{
    var options = builder.Configuration.GetSection("Fundamentus").Get<FundamentusOptions>();

    if (options == null || string.IsNullOrWhiteSpace(options.BaseUrl))
        throw new InvalidOperationException("Fundamentus BaseUrl is not configured.");

    client.BaseAddress = new Uri(options.BaseUrl);
});

var app = builder.Build();

// Use Swagger in production as well for API documentation
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();