using Common.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Storage
{
    public class UserDbContext : BaseContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Entities.User> Users { get; set; }
        public UserDbContext(IConfiguration configuration)
          : base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //var constring = "server=localhost;database=User;User=root;Password=root;";
            var constring = "server=localhost;database=User;User=aaa;Password=aaa;";
            options.UseMySql(constring, ServerVersion.AutoDetect(constring));
        }
    }
}
