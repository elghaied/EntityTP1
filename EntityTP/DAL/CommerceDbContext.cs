

using Microsoft.EntityFrameworkCore;

namespace EntityTP.DAL
{
    public class CommerceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=NAMELESS;Integrated Security=True;Trust Server Certificate=True;Initial catalog=AJC_DEMO");
        }

        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Personne> Personnes {  get; set; }
        public DbSet<PersonneSyndiquee> personneSyndiquees { get; set; }   
        public DbSet<Societe> Societes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>().ToTable("Personnes");
            modelBuilder.Entity<PersonneSyndiquee>().ToTable("PersonneSyndiquees");
            //GESTION FLUENT API MANY TO MANY
            modelBuilder.Entity<Societe>()
            .HasMany(a => a.Adresses)
            .WithMany(s => s.Etablissements);

            //GESTION FLUENT API ZERO TO MANY
            modelBuilder.Entity<Adresse>()
            .HasMany(a => a.Personnes)
            .WithOne(p => p.AdressePrincipale)
            .HasForeignKey(p => p.AdressePrincipaleId);

            modelBuilder.Entity<Adresse>()
            .HasMany(a => a.PersonnesSecondaire)
            .WithOne(p => p.AdresseSecondaire)
            .HasForeignKey(p => p.AdresseSecondaireId);

            modelBuilder.Entity<Adresse>().HasMany(a => a.Societes).WithOne(s => s.SiegeSocial).HasForeignKey(s => s.AdresseId).IsRequired();
        }
    }
}
