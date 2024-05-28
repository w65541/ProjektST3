using User.Api.Extensions;
using User.CrossCutting.Dtos;
using User.Storage;

namespace User.Api.Services
{
    public class UserService
    {
        UserDbContext _dbContext;
        public UserService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Delete(int id) 
        {
            Storage.Entities.User entity = _dbContext.Users.Where(e => e.Id == id).FirstOrDefault();
            if (entity == null) { return false; }
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public UserDto GetById(int id)
        {
            Storage.Entities.User entity = _dbContext.Users.Where(e => e.Id == id).FirstOrDefault();
            if (entity == null) { return null; }
            return entity.ToDto();
        }
        public bool Update(Storage.Entities.User newentity)
        {

            Storage.Entities.User entity = _dbContext.Users.Where(e => e.Id == newentity.Id).FirstOrDefault();
            if (entity == null)
            {
                return false;
            }
            entity.Login = newentity.Login;
            entity.Haslo = newentity.Haslo;
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<UserDto> Get()
        {
            var entity = _dbContext.Users.ToList();

            return entity.Select(e => e.ToDto());
        }

        public UserDto Create(UserDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

            var newDto = GetById(entity.Id);

            return newDto;
        }
    }
}
