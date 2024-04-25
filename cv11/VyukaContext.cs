using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class VyukaContext : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Predmet> Predmety { get; set; }
        public DbSet<Hodnoceni> Hodnoceni { get; set; }
        public DbSet<Zapsani> Zapsani { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("D:\\bpc-oop\\bpc-oop-246976\\CV10.2\\Vyuka.MDF");
        }
    }
}
