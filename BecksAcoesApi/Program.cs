using Infra;
using Infra.Http.Configurations;
using Infra.Http.ExternalApiServices;
using Infra.Http.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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