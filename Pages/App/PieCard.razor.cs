using learning_aspdotnet.Models;
using Microsoft.AspNetCore.Components;

namespace learning_aspdotnet.Pages.App
{
    public partial class PieCard 
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }

}
