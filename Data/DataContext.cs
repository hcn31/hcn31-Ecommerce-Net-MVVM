using Microsoft.EntityFrameworkCore;
using TPPro.Model;

namespace TPPro.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Produit> Produits { get; set; }
        public DataContext()
        {

        }


    }
}
