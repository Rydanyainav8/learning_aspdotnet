namespace scratch_shop_app.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories {  get; }
    }
}
