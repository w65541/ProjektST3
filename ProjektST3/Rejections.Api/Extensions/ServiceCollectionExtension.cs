using Rejections.Api.Services;
using Rejections.Storage;

namespace Rejections.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRejectionServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient<RejectionService>();
            serviceCollection.AddDbContext<RejectionDbContext, RejectionDbContext>();
            return serviceCollection;
        }
    }
}
