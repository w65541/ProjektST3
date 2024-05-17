using Common.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Profil.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profil.Storage
{
    public class ProfilDbContext : BaseContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Profile> Profiles { get; set; }
        public ProfilDbContext(IConfiguration configuration)
          : base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var constring = "server=localhost;database=Profile;User=root;Password=root;";
            options.UseMySql(constring, ServerVersion.AutoDetect(constring));
        }
    }
}
