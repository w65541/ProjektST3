using Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profil.Storage.Entities
{
    public class Profile : BaseEntity
    {
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
