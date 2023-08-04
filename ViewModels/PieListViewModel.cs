using scratch_shop_app.Models;

namespace scratch_shop_app.ViewModel
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; }

        public string? CurrentCategory { get; }

        public PieListViewModel(IEnumerable<Pie> pies, string? currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }       
    }
}
  