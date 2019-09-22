using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJbos.Modele
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Candidat> Candidat { get; set; }


       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidat>(entity =>
            {
                entity.HasKey(e => e.Id_candidat);

                entity.ToTable("Candidat");

                entity.Property(e => e.Id_candidat)
                    .HasColumnName("Id_candidat")
                    .ValueGeneratedOnAdd ();

                
                entity.Property(e => e.Nom_candidat)
                    .HasMaxLength(20)
                    .IsRequired(true);

                entity.Property(e => e.Prenom_candidat)
                    .HasMaxLength(15)
                    .IsRequired(true);

                entity.Property(e => e.Courriel)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Mot_passe)
                .HasMaxLength(15)
                .IsRequired(true);

                entity.Property(e => e.Tel)
                    .HasMaxLength(10)
                    .IsRequired(true);

                entity.Property(e => e.Statut)
                    .HasMaxLength(10)
                    .IsRequired(true);
                    
            });
        }
    }

}
