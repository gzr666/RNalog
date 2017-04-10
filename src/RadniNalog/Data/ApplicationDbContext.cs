using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RadniNalog.Models;

namespace RadniNalog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Automobil> Automobili { get; set; }
        public DbSet<MjestoRada> MjestoRada { get; set; }
        public DbSet<RNalog> RadniNalozi { get; set; }
        public DbSet<VrstaRada> VrstaRada { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Automobil>().ToTable("Automobil");
            builder.Entity<MjestoRada>().ToTable("MjestoRada");
            builder.Entity<RNalog>().ToTable("RadniNalog");
            builder.Entity<VrstaRada>().ToTable("VrstaRada");
            builder.Entity<Zaposlenik>().ToTable("Zaposlenik");


        }

        
    }
}
