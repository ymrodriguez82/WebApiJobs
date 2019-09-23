using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiJobs.Modele;

namespace WebApiJbos.Modele
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Candidat> Candidat { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Offre> Offre { get; set; }
        public DbSet<Favoris> Favoris { get; set; }
        public DbSet<Evenement> Evenement { get; set; }
        public DbSet<Rappel> Rappel { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Candidat
            modelBuilder.Entity<Candidat>(entity =>
            {
                entity.HasKey(e => e.Id_candidat);

                entity.ToTable("Candidat");
                
                entity.Property(e => e.Nom_candidat)
                    .HasMaxLength(20)
                    .IsRequired(true);

                entity.Property(e => e.Prenom_candidat)
                    .HasMaxLength(15)
                    .IsRequired(true);

                entity.Property(e => e.Courriel)
                    .HasMaxLength(35);

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

            //Contact
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id_contact);

                entity.ToTable("Contact");

               entity.Property(e => e.Nom_contact)
                    .HasMaxLength(20)
                    .IsRequired(true);

                entity.Property(e => e.Prenom_contact)
                    .HasMaxLength(15)
                    .IsRequired(true);

                entity.Property(e => e.Courriel_contact)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Poste)
                .HasMaxLength(15)
                .IsRequired(true);

                entity.Property(e => e.Tel_contact)
                    .HasMaxLength(10)
                    .IsRequired(true);

            });

            //Evenement
            modelBuilder.Entity<Evenement>(entity =>
            {
                entity.HasKey(e => e.Id_evenement);

                entity.ToTable("Evenement");

                entity.Property(e => e.Titre)
                    .HasMaxLength(20)
                    .IsRequired(true);

                entity.Property(e => e.Date_event);

                entity.Property(e => e.Heure)
                .HasMaxLength(5)
                .IsRequired(true);

                entity.Property(e => e.Adresse)
                    .HasMaxLength(10);

                entity.Property(e => e.Descr)
                    .HasMaxLength(10);

            });

            //Favorite
            modelBuilder.Entity<Favoris>(entity =>
            {
                entity.HasKey(e => new { e.Id_candidat, e.Id_offre});

                entity.ToTable("Favoris");


            });

            //Rappel
            modelBuilder.Entity<Rappel>(entity =>
            {
                entity.HasKey(e => e.Id_rappel);

                entity.ToTable("Rappel");


            });

            //Offre
            modelBuilder.Entity<Offre>(entity =>
            {
                entity.HasKey(e => e.Id_offre);

                entity.ToTable("Offre");


            });




        }
    }

}
