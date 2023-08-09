﻿using Microsoft.AspNetCore.Mvc;
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
        public ViewResult List(string category) 
        {
            IEnumerable<Pie> pies;
            string? currentCategory;
            if(string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new PieListViewModel(pies, currentCategory));
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
