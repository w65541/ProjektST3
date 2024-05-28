using Webpage.ExternalDto;

namespace Webpage.Resolvers
{
    public class ProfileResolver
    {
        public ProfileDto GetById(int id) { return new ProfileDto(); }
        public List<ProfileDto> Get()
        {
            return new List<ProfileDto>();
        }
    }
}
