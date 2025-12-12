using Microsoft.EntityFrameworkCore;
using Project.Models;
namespace Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<ProfesoriPredmeti> ProfesoriPredmeti { get; set; }
        public DbSet<Smer> Smerovi { get; set; }
        public DbSet<StudentiPredmeti> StudentiPredmeti { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Smer)
                .WithMany(st => st.Studenti)
                .HasForeignKey(s => s.SmerId);
            modelBuilder.Entity<Predmet>()
                .HasOne(s => s.Smer)
                .WithMany(p => p.Predmeti)
                .HasForeignKey(s => s.SmerId);
            modelBuilder.Entity<StudentiPredmeti>()
                .HasOne(sp => sp.Student)
                .WithMany(s => s.StudentiPredmeti)
                .HasForeignKey(sp => sp.StudentId);
            modelBuilder.Entity<StudentiPredmeti>()
                .HasOne(p => p.Predmet)
                .WithMany(s => s.StudentiPredmeti)
                .HasForeignKey(p => p.PredmetId);
            modelBuilder.Entity<ProfesoriPredmeti>()
                .HasOne(p => p.Profesor)
                .WithMany(pp => pp.ProfesoriPredmeti)
                .HasForeignKey(p => p.ProfesorId);
            modelBuilder.Entity<ProfesoriPredmeti>()
                .HasOne(p => p.Predmet)
                .WithMany(pp => pp.ProfesoriPredmeti)
                .HasForeignKey(p => p.PredmetId);

        }
    }
}
