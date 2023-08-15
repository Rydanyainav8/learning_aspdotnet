using Microsoft.EntityFrameworkCore;

namespace learning_aspdotnet.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly ScratchShopAppDbContext _scratchShopAppDbContext;

        public PieRepository(ScratchShopAppDbContext scratchShopAppDbContext)
        {
            _scratchShopAppDbContext = scratchShopAppDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _scratchShopAppDbContext.Pies.Include(c => c.Category);
            }
        }
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _scratchShopAppDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _scratchShopAppDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _scratchShopAppDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
