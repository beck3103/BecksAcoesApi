using Application.AppServices;
using Application.Interfaces;
using Infra.Http.ExternalApiServices;
using Infra.Http.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class ServicesRegister
{
    public static void RegisterServices(this IServiceCollection services)
    {
        RegisterExternalApiServices(services);
        RegisterAppServices(services);
    }

    private static void RegisterExternalApiServices(this IServiceCollection services) =>
        services.AddScoped<IFundamentusHttpClient, FundamentusHttpClient>();

    private static void RegisterAppServices(this IServiceCollection services) =>
        services.AddScoped<IAuthenticationAppService, AuthenticationAppService>()
                .AddScoped<IFundamentusAppService, FundamentusAppService>();
}