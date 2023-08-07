using Microsoft.AspNetCore.Mvc;
using learning_aspdotnet.Models;
using learning_aspdotnet.ViewModel;

namespace learning_aspdotnet.Controllers
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
