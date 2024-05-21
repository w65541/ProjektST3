using Profil.Api.Extensions;
using Profil.CrossCutting.Dtos;
using Profil.Storage;
using Profil.Storage.Entities;

namespace Profil.Api.Services
{
    public class ProfilServices
    {
        ProfilDbContext _dbContext;
        public ProfilServices(ProfilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProfileDto GetById(int id)
        {
            Profile entity = _dbContext.Profiles.Where(e => e.Id == id).FirstOrDefault();
            if (entity == null) { return null; }
            return entity.ToDto();
        }
        public bool Update(Profile entity)
        {

            Profile oldentity = _dbContext.Profiles.Where(e => e.Id == entity.Id).FirstOrDefault();
            if (entity == null)
            {
                return false;
            }
            oldentity.Atrybut1 = entity.Atrybut1;
            oldentity.Atrybut2 = entity.Atrybut2;
            oldentity.Atrybut3 = entity.Atrybut3;
            oldentity.Atrybut4 = entity.Atrybut4;
            oldentity.IdUser = entity.IdUser;
            oldentity.Email = entity.Email;
            oldentity.Imie = entity.Imie;
            oldentity.Nazwisko = entity.Nazwisko;
            oldentity.Plec = entity.Plec;
            oldentity.Telefon = entity.Telefon;
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<ProfileDto> Get()
        {
            var entity = _dbContext.Profiles.ToList();

            return entity.Select(e => e.ToDto());
        }

        public ProfileDto Create(ProfileDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Profiles.Add(entity);
            _dbContext.SaveChanges();

            var newDto = GetById(entity.Id);

            return newDto;
        }
    }
}
