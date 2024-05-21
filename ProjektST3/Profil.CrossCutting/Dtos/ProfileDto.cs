using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profil.CrossCutting.Dtos
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public sbyte Plec { get; set; }
        public int Atrybut1 { get; set; }
        public int Atrybut2 { get; set; }
        public int Atrybut3 { get; set; }
        public int Atrybut4 { get; set; }
    }
}
