using Rejections.CrossCutting.Dtos;
using Rejections.Storage.Entities;

namespace Rejections.Api.Extensions
{
    public static class RejectionExtension
    {
        public static Rejection ToEntity(this RejectionDto dto)
        {
            return new Rejection
            {
                Id = dto.Id,
                Rejected = dto.Rejected,
                Rejectee = dto.Rejectee,
            };
        }

        public static RejectionDto ToDto(this Rejection entity)
        {
            return new RejectionDto
            {
                Id = entity.Id,
                Rejected = entity.Rejected,
                Rejectee = entity.Rejectee,
            };
        }
    }
}
