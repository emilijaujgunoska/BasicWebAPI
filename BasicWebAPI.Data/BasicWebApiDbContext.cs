using BasicWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace BasicWebAPI.Data
{
    public class BasicWebApiDbContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public BasicWebApiDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionString"));


        }
            


    }
}


