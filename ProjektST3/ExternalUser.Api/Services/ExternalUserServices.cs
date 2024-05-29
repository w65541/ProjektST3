using Common.Api;
using Common.CrossCutting.Dtos;
using Common.CrossCutting.Enums;
using ExternalUser.Api.Extensions;
using ExternalUser.CrossCutting.Dtos;
using ExternalUser.Storage;

namespace ExternalUser.Api.Services
{
    public class ExternalUserServices : CrudServiceBase<ExternalUserDbContext, ExternalUser.Storage.Entities.ExternalUser, ExternalUserDto>
    {
        ExternalUserDbContext _dbContext;
        public ExternalUserServices(ExternalUserDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ExternalUserDto> GetById(int id)
        {
            var entity = await base.GetById(id);

            return entity?.ToDto();
        }

        public async Task<IEnumerable<ExternalUserDto>> Get()
        {
            var entities = await base.Get();

            return entities.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<ExternalUserDto>> Create(ExternalUserDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entity.Id);


            return new CrudOperationResult<ExternalUserDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<ExternalUserDto>> Delete(int id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<ExternalUserDto>> Update(int id, ExternalUserDto newdto)
        {
            var newEntity = newdto.ToEntity();
            return await base.Update(id, newEntity);
        }
    }
}

/*
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
*/