using GruppeProjekt.model;
using GruppeProjekt.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GruppeProjekt.Pages.Burgere
{
    public class DeleteBurgerModel : PageModel
    {
        private IBurgerRepository _repo;

        public DeleteBurgerModel(IBurgerRepository repo)
        {
            _repo = repo;
        }

        public Burger Burger { get; private set; }

        public IActionResult OnGet(int pris)
        {
            Burger = _repo.HentBurger(pris);

            return Page();
        }

        public IActionResult OnPostDelete(int pris)
        {
            _repo.Slet(pris);

            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}