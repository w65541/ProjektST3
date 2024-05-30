using Profil.Api.Services;
using Profil.Storage;

namespace Profil.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProfileServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient<ProfilServices>();
            serviceCollection.AddDbContext<ProfilDbContext, ProfilDbContext>();
            return serviceCollection;
        }
    }
}
