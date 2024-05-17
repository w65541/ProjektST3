using Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalUser.Storage.Entities
{
    public class ExternalUser : BaseEntity
    {
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Email { get; set; }
    }
}
