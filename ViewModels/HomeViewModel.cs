using learning_aspdotnet.Models;

namespace learning_aspdotnet.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek) 
        {
            PiesOfTheWeek = piesOfTheWeek;
        }  
    }
}
