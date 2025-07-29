using CnpjControl.Application.Contracts.Company;
using CnpjControl.Persistence.DbContext;
using CnpjControl.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CnpjControl.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddHttpClient();
        return services;
    }
}