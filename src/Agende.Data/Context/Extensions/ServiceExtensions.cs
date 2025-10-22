using Agende.Business.Interfaces.HttpServices;
using Agende.Business.Interfaces.Repositories;
using Agende.Business.Interfaces.Repositories.Base;
using Agende.Business.Interfaces.Services;
using Agende.Business.Services;
using Agende.Business.Services.Base;
using Agende.Business.Services.HttpServices;
using Agende.Data.Repositories;
using Agende.Data.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Agende.Data.Context.Extensions;
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