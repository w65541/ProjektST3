using ExternalUser.Api.Services;
using ExternalUser.Storage;

namespace ExternalUser.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient<ExternalUserServices>();
            serviceCollection.AddDbContext<ExternalUserDbContext, ExternalUserDbContext>();
            return serviceCollection;
        }
    }
}
