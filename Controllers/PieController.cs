using Microsoft.AspNetCore.Mvc;
using scratch_shop_app.Models;
using scratch_shop_app.ViewModel;

namespace scratch_shop_app.Controllers
{ 
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository ieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = ieRepository;
            _categoryRepository = categoryRepository;
        }   
        public IActionResult List() 
        {
            //ViewBag.CurrentCategory = "Cheese Cake";
            //return View(_pieRepository.AllPies);
            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");
            return View(piesListViewModel);
        }
    }
}
