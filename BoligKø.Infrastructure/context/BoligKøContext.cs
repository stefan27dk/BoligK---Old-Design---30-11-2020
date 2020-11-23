using BoligKø.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BoligKø.Infrastructure.context
{
    public class BoligKøContext : DbContext
    {
        public DbSet<Ansøger> Ansøgere { get; set; }
        public DbSet<Ansøgning> Ansøgninger { get; set; }

        public BoligKøContext(DbContextOptions<BoligKøContext> options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            addKriterieEntities(builder);
        }

        private void addKriterieEntities(ModelBuilder builder)
        {
            builder.Entity<KvmKriterie>();
            builder.Entity<LejemålsTypeKriterie>();
            builder.Entity<LokationKriterie>();
            builder.Entity<PrisKriterie>();
            builder.Entity<TilladtDyrKriterie>();
            builder.Entity<VærelsesKriterie>();
        }
    }

    }
