using Common.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rejections.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejections.Storage
{
    public class RejectionDbContext: BaseContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Rejection> Rejections { get; set; }
        public RejectionDbContext(IConfiguration configuration)
          : base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var constring = "server=localhost;database=Rejection;User=root;Password=root;";
            //var constring = "server=localhost;User=aaa;Password=aaa;database=Rejection;";
            options.UseMySql(constring, ServerVersion.AutoDetect(constring));
        }
    }
}
