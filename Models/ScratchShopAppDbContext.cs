using Microsoft.EntityFrameworkCore;

namespace learning_aspdotnet.Models
{
    public class ScratchShopAppDbContext: DbContext
    {
        public ScratchShopAppDbContext(DbContextOptions<ScratchShopAppDbContext>options) : base(options)
        {
        
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Pie> Pies { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }  
}
