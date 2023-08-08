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
            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "All pies"); 
            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if(pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
