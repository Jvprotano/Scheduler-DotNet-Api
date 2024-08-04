using Bie.Business.Interfaces.HttpServices;
using Bie.Business.Interfaces.Repositories;
using Bie.Business.Interfaces.Repositories.Base;
using Bie.Business.Interfaces.Services;
using Bie.Business.Services;
using Bie.Business.Services.Base;
using Bie.Business.Services.HttpServices;
using Bie.Data.Repositories;
using Bie.Data.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Bie.Data.Context.Extensions;
public static class ServiceExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IService<>), typeof(Service<>));

        #region Repositories
        services.AddScoped<ISchedulingRepository, SchedulingRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICompanyOpeningHoursRepository, CompanyOpeningHoursRepository>();
        #endregion

        #region Services
        services.AddScoped<ISchedulingService, SchedulingService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IOpenAIService, OpenAIService>();
        services.AddScoped<IImageUploadService, ImageUploadService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        #endregion
    }
}