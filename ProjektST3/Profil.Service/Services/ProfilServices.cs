using Common.Api;
using Common.CrossCutting.Dtos;
using Common.CrossCutting.Enums;
using Profil.Api.Extensions;
using Profil.CrossCutting.Dtos;
using Profil.Storage;
using Profil.Storage.Entities;

namespace Profil.Api.Services
{
    public class ProfilServices : CrudServiceBase<ProfilDbContext, Profile, ProfileDto>
    {
        ProfilDbContext _dbContext;
        public ProfilServices(ProfilDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProfileDto> GetById(int id)
        {
            var entity = await base.GetById(id);

            return entity.ToDto();
        }

        public async Task<IEnumerable<ProfileDto>> Get()
        {
            var entities = await base.Get();

            return entities.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<ProfileDto>> Create(ProfileDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entity.Id);


            return new CrudOperationResult<ProfileDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<ProfileDto>> Delete(int id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<ProfileDto>> Update(int id, ProfileDto newdto)
        {
            var newEntity = newdto.ToEntity();
            return await base.Update(id, newEntity);
        }
    }
}