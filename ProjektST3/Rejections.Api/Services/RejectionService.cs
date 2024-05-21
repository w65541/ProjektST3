using Microsoft.EntityFrameworkCore;
using Rejections.Api.Extensions;
using Rejections.CrossCutting.Dtos;
using Rejections.Storage;
using Rejections.Storage.Entities;

namespace Rejections.Api.Services
{
    public class RejectionService
    {
        RejectionDbContext _dbContext;
        public RejectionService(RejectionDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public RejectionDto GetById(int id)
        {
            Rejection entity = _dbContext.Rejections.Where(e=>e.Id==id).FirstOrDefault();
            if (entity == null) { return null; }
            return entity.ToDto();
        }
        public bool Update(Rejection newentity)
        {

            Rejection entity = _dbContext.Rejections.Where(e => e.Id == newentity.Id).FirstOrDefault();
            if (entity == null)
            {
                return false;
            }
            entity.Rejectee = newentity.Rejectee;
            entity.Rejected = newentity.Rejected;
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<RejectionDto> Get()
        {
            var entity = _dbContext.Rejections.ToList();

            return entity.Select(e => e.ToDto());
        }

        public RejectionDto Create(RejectionDto dto)
        {
            var entity = dto.ToEntity();
            _dbContext.Rejections.Add(entity);
            _dbContext.SaveChanges();

            var newDto =  GetById(entity.Id);

            return newDto;
        }
    }
}
