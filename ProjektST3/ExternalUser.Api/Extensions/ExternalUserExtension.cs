using ExternalUser.CrossCutting.Dtos;
using ExternalUser.Storage.Entities;

namespace ExternalUser.Api.Extensions
{
    public static class ExternalUserExtension
    {
        public static Storage.Entities.ExternalUser ToEntity(this ExternalUserDto dto)
        {
            return new Storage.Entities.ExternalUser
            {
                Id = dto.Id,
                Login = dto.Login,
                Haslo = dto.Haslo,
                Email=dto.Email
            };
        }

        public static ExternalUserDto ToDto(this Storage.Entities.ExternalUser entity)
        {
            return new ExternalUserDto
            {
                Id = entity.Id,
                Login = entity.Login,
                Haslo = entity.Haslo,
                Email = entity.Email
            };
        }
    }
}
