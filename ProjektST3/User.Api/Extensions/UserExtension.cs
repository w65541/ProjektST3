using User.CrossCutting.Dtos;

namespace User.Api.Extensions
{
    public static class UserExtension
    {
        public static Storage.Entities.User ToEntity(this UserDto dto)
        {
            return new Storage.Entities.User
            {
                Id = dto.Id,
                Login = dto.Login,
                Haslo = dto.Haslo,
            };
        }

        public static UserDto ToDto(this Storage.Entities.User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                Login = entity.Login,
                Haslo = entity.Haslo,
            };
        }
    }
}
