using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArmyHammerProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public virtual ICollection<Llista> LlistesUser { get; set; }

    }
    public class ArmyContext : IdentityDbContext<ApplicationUser>
    {

        public ArmyContext()
            : base("ArmyContext", throwIfV1Schema: false)
        {
        }
        public static ArmyContext Create()
        {
            return new ArmyContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Miniatura>()
            .HasRequired(r => r.Raça)
            .WithMany(r => r.Miniatures)
            .HasForeignKey(r => r.RaçaID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Llista>()
            .HasRequired(r => r.Raça)
            .WithMany(r => r.Llistes)
            .HasForeignKey(r => r.RaçaID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<ObjectesMini>()
            .HasRequired(o => o.Miniatura)
            .WithMany(o => o.Objectes)
            .HasForeignKey(o => o.MiniaturaID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<ObjectesMini>()
            .HasRequired(o => o.Objecte)
            .WithMany(o => o.Miniatures)
            .HasForeignKey(o => o.ObjecteID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<MinisPerLlista>()
            .HasRequired(o => o.Miniatura)
            .WithMany(o => o.Llistes)
            .HasForeignKey(o => o.MiniaturaID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<MinisPerLlista>()
            .HasRequired(o => o.Llista)
            .WithMany(o => o.Miniatures)
            .HasForeignKey(o => o.LlistaID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Llista>()
            .HasRequired(o => o.Usuari)
            .WithMany(o => o.LlistesUser)
            .HasForeignKey(o => o.UsuariID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<ArmyHammerProject.Models.Llista> Llistes { get; set; }

        public System.Data.Entity.DbSet<ArmyHammerProject.Models.Miniatura> Miniatures { get; set; }

        public System.Data.Entity.DbSet<ArmyHammerProject.Models.MinisPerLlista> MinisPerLlistes { get; set; }

        public System.Data.Entity.DbSet<ArmyHammerProject.Models.Objecte> Objectes { get; set; }

        public System.Data.Entity.DbSet<ArmyHammerProject.Models.ObjectesMini> ObjectesMinis { get; set; }

        public System.Data.Entity.DbSet<ArmyHammerProject.Models.Raça> Races { get; set; }

        //public System.Data.Entity.DbSet<ArmyHammerProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        public System.Collections.IEnumerable ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<ArmyHammerProject.Models.RoleViewModel> RoleViewModels { get; set; }

        public DbSet<Imatge> FilePaths { get; set; }
    }
}