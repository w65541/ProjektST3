using Common.Api;
using Common.CrossCutting.Dtos;
using Common.CrossCutting.Enums;
using Microsoft.EntityFrameworkCore;
using Rejections.Api.Extensions;
using Rejections.CrossCutting.Dtos;
using Rejections.Storage;
using Rejections.Storage.Entities;

namespace Rejections.Api.Services
{
    public class RejectionService : CrudServiceBase<RejectionDbContext, Rejection, RejectionDto>
    {
        RejectionDbContext _dbContext;
        public RejectionService(RejectionDbContext dbContext) : base(dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task<RejectionDto> GetById(int id)
        {
            var entity = await base.GetById(id);

            return entity?.ToDto();
        }

        public async Task<IEnumerable<RejectionDto>> Get()
        {
            var entities = await base.Get();

            return entities.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<RejectionDto>> Create(RejectionDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entity.Id);


            return new CrudOperationResult<RejectionDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<RejectionDto>> Delete(int id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<RejectionDto>> Update(int id, RejectionDto newdto)
        {
            var newEntity = newdto.ToEntity();
            return await base.Update(id, newEntity);
        }
    }
}
