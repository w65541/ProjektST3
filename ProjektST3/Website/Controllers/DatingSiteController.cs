using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.ExternalDto;
using Website.Models;
using Website.Resolvers;
using Website.Resolvers;


namespace Website.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class DatingSiteController : ControllerBase
    {

        private readonly UserResolver _user;
        private readonly ProfileResolver _profile;
        private readonly RejectionResolver _rejection;
        private readonly ExternalUserResolver _externalUser;
        private readonly ILogger<DatingSiteController> _logger;

        public DatingSiteController(ILogger<DatingSiteController> logger, ProfileResolver profile, UserResolver user, RejectionResolver rejection, ExternalUserResolver externalUser)
        {
            _logger = logger;
            _profile = profile;
            _rejection = rejection;
            _user = user;
            _externalUser = externalUser;
        }

        //Funkcja zwraca id użytkownika przy poprawnym logowaniu
        [HttpGet("LoginUser")]
        public int GetId(string login, string password)
        {
            Console.WriteLine(login + " " + password);
            var userList = _user.Get().Result;
            var temp = userList.Where(x => x.Login.Equals(login) && x.Haslo.Equals(password)).FirstOrDefault();
            if (temp != null)
            {
                int id = temp.Id;
                Console.WriteLine(id);
                return id;
            }

            return 0;
        }

        //Zwraca profil użytkownia o podanym UserId
        [HttpGet("ProfileGet")]
        public ProfileDto GetProfil(int id)
        {
            var temp = _profile.GetByIdAsync(id);
            if (temp != null) return temp.Result;
            return null;
        }


        //Usuwa wszystko związane z danym użytkownikiem o podannym id
        [HttpGet("ProfileDelete")]
        public int DeleteProfile(int id)
        {
            var temp = _profile.GetByIdAsync(id);
            if (temp != null) {

                _profile.Delete(id);
                _user.Delete(id);
                foreach (var item in _rejection.Get().Result.Where(x => x.Rejectee == id))
                {
                    _rejection.Delete(item.Id);
                }
                return 0;
            }
            return 1;
        }
        //dodaje nowego użytkownika
        [HttpGet("ProfileAdd")]
        public async Task<int> AddProfileAsync(string login = "", string haslo = "", string imie = "", string nazwisko = "", string telefon = "", string email = "", sbyte plec = 2, int a1 = 0, int a2 = 0, int a3 = 0, int a4 = 0)
        {
            if (login.Length < 46 && haslo.Length < 46 && imie.Length < 46 && nazwisko.Length < 46 && telefon.Length == 9 && int.TryParse(telefon, out int ignore) && email.Contains('@') && email.Length < 46)
            {
                await _user.Add(new UserDto { Login = login, Haslo = haslo });
                int id = _user.Get().Result.Last().Id;
                await _profile.Add(new ProfileDto {
                    IdUser = id,
                    Imie = imie,
                    Nazwisko = nazwisko,
                    Telefon = telefon,
                    Plec = plec,
                    Atrybut1 = a1,
                    Atrybut2 = a2,
                    Atrybut3 = a3,
                    Atrybut4 = a4
                });

                return 0;
            }
            return 1;
        }
        //Aktualizuje dane użytkownika o podanym id
        [HttpGet("ProfileUpdate")]
        public async Task<int> UpdateProfileAsync(int id, string imie = "", string nazwisko = "", string telefon = "", string email = "", int a1 = 0, sbyte plec = 2, int a2 = 0, int a3 = 0, int a4 = 0) {

            if (imie.Length < 46 && nazwisko.Length < 46 && telefon.Length == 9 && int.TryParse(telefon, out int ignore) && email.Contains('@') && email.Length < 46)
            {

                await _profile.Update(id, new ProfileDto
                {
                    Id = id,
                    IdUser = id,
                    Imie = imie,
                    Nazwisko = nazwisko,
                    Telefon = telefon,
                    Plec = plec,
                    Atrybut1 = a1,
                    Atrybut2 = a2,
                    Atrybut3 = a3,
                    Atrybut4 = a4
                });
                return 0;
            }

            return 1;
        }

        //dodaje do odrzuconych danego użytkownika odrzucanego o podanym id
        [HttpGet("Reject")]
        public async Task<int> RejectAsync(int id1, int id2)
        {
            await _rejection.Add(new RejectionDto { Rejectee = id1, Rejected = id2 });
            return 0;
        }


        //Zwraca listę kandytatów posortowną po największej kompatybilności
        [HttpGet("ProfileCom")]
        public List<ProfileDto> PotencjalneProfile(int id = 1)
        {
            var profil = _profile.GetByIdAsync(id).Result;
            List<ProfileDto> profils = _profile.GetAsync().Result;
            List<int> rejected = new List<int>();
            foreach (var item in _rejection.Get().Result.Where(x => x.Rejectee == id).ToList())
            {
                rejected.Add(item.Rejected);
            }
            List<ratedProfile> profile = new List<ratedProfile>();
            foreach (var item in profils.Where(x => x.Plec != profil.Plec && !rejected.Contains(x.Id)))
            {
                int i = (int)(profil.Atrybut1 - item.Atrybut1 + profil.Atrybut2 - item.Atrybut2 + profil.Atrybut3 - item.Atrybut3 + profil.Atrybut4 - item.Atrybut4) * (int)(profil.Atrybut1 - item.Atrybut1 + profil.Atrybut2 - item.Atrybut2 + profil.Atrybut3 - item.Atrybut3 + profil.Atrybut4 - item.Atrybut4);
                profile.Add(new ratedProfile { profil = item, ocena = i });
            }
            profile = profile.OrderBy(x => x.ocena).ToList();
            return profile.Select(x => x.profil).ToList();
        }

        [HttpGet("LoginExternalUser")]
        public string GetExternalEmail(string login, string password)
        {
            Console.WriteLine(login + " " + password);
            var userList = _externalUser.Get().Result;
            var temp = userList.Where(x => x.Login.Equals(login) && x.Haslo.Equals(password)).FirstOrDefault();
            if (temp != null)
            {
                
               
                return temp.Email;
            }

            return "0";
        }
    }
}
