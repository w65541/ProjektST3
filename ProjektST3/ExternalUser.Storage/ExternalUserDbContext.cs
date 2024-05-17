using Common.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalUser.Storage
{
    public class ExternalUserDbContext : BaseContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Entities.ExternalUser> ExternalUsers { get; set; }
        public ExternalUserDbContext(IConfiguration configuration)
          : base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var constring = "server=localhost;database=ExternalUser;User=root;Password=root;";
            options.UseMySql(constring, ServerVersion.AutoDetect(constring));
        }
    }
}
