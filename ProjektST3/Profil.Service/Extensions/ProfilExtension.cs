using Profil.CrossCutting.Dtos;
using Profil.Storage.Entities;

namespace Profil.Api.Extensions
{
    public static class ProfilExtension
    {
        public static Profile ToEntity(this ProfileDto dto)
        {
            return new Profile
            {
                Id = dto.Id,
                Atrybut1=dto.Atrybut1,
                Atrybut2=dto.Atrybut2,
                Atrybut3= dto.Atrybut3,
                Atrybut4=dto.Atrybut4,
                IdUser=dto.IdUser,
                Email=dto.Email,
                Imie=dto.Imie,
                Nazwisko=dto.Nazwisko,
                Plec=dto.Plec,
                Telefon=dto.Telefon
                
            };
        }

        public static ProfileDto ToDto(this Profile entity)
        {
            return new ProfileDto
            {
                Id = entity.Id,
                Atrybut1 = entity.Atrybut1,
                Atrybut2 = entity.Atrybut2,
                Atrybut3 = entity.Atrybut3,
                Atrybut4 = entity.Atrybut4,
                IdUser = entity.IdUser,
                Email = entity.Email,
                Imie = entity.Imie,
                Nazwisko = entity.Nazwisko,
                Plec = entity.Plec,
                Telefon = entity.Telefon
            };
        }
    }
}
