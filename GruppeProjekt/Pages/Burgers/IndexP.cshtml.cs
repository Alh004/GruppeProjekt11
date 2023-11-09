using GruppeProjekt.model;
using GruppeProjekt.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace GruppeProjekt.Pages.Burgere
{
    public class IndexModelP : PageModel
    {
        // instance of burger repository
        private IBurgerRepository _repo;

        // Dependency Injection
        public IndexModelP(IBurgerRepository repository)
        {
            _repo = repository;
        }

        // property for the View
        public List<Burger> Burgere { get; set; }

        public void OnGet()
        {
            //BurgerRepository repo = new BurgerRepository(true);

            Burgere = _repo.HentAlleBurgere();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("NyBurger");
        }
    }
}