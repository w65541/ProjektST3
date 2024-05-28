using User.Api.Services;
using User.Storage;

namespace User.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddTransient<UserService>();
            serviceCollection.AddDbContext<UserDbContext, UserDbContext>();
            return serviceCollection;
        }
    }
}
