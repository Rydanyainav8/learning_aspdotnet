namespace scratch_shop_app.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Pie>? Pies { get; set; }
    }
}
