using BoligKø.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Infrastructure.context
{
    public class BoligKøContext : DbContext
    {
        public DbSet<Ansøger> Ansøgere { get; set; }
        public DbSet<Ansøgning> Ansøgninger { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=BoligKø;Integrated Security=True");
        }

    }
}
