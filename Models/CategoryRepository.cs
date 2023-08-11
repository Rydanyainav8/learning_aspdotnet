namespace learning_aspdotnet.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ScratchShopAppDbContext _scratchShopAppDbContext;

        public CategoryRepository(ScratchShopAppDbContext scratchShopAppDbContext)
        {
            _scratchShopAppDbContext = scratchShopAppDbContext;
        }
        public IEnumerable<Category> AllCategories =>
            _scratchShopAppDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
