using ExternalUser.Api.Extensions;
using ExternalUser.CrossCutting.Dtos;
using ExternalUser.Storage;

namespace ExternalUser.Api.Services
{
    public class ExternalUserServices
    {
        ExternalUserDbContext _dbContext;
        public ExternalUserServices(ExternalUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ExternalUserDto GetById(int id)
        {
            Storage.Entities.ExternalUser entity = _dbContext.ExternalUsers.Where(e => e.Id == id).FirstOrDefault();
            if (entity == null) { return null; }
            return entity.ToDto();
        }
        public bool Update(Storage.Entities.ExternalUser newentity)
        {

            Storage.Entities.ExternalUser entity = _dbContext.ExternalUsers.Where(e => e.Id == newentity.Id).FirstOrDefault();
            if (entity == null)
            {
                return false;
            }
            entity.Login = newentity.Login;
            entity.Haslo = newentity.Haslo;
            entity.Email = newentity.Email;
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<ExternalUserDto> Get()
        {
            var entity = _dbContext.ExternalUsers.ToList();

            return entity.Select(e => e.ToDto());
        }

        public ExternalUserDto Create(ExternalUserDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.ExternalUsers.Add(entity);
            _dbContext.SaveChanges();

            var newDto = GetById(entity.Id);

            return newDto;
        }
    }
}
