using HospitalProjectServer.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalProjectServer.DataAccess;
public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this ServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql("").UseSnakeCaseNamingConvention();
        });
        return services;
    }
}
