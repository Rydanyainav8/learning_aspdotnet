using learning_aspdotnet.Models;

namespace learning_aspdotnet.ViewModel
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
