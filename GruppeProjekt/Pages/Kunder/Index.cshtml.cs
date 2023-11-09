using GruppeProjekt.model;
using GruppeProjekt.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GruppeProjekt.Pages.Kunder
{
    public class IndexModel : PageModel
    {
        // instans af kunde repository
        private IKundeRepository _repo;

        // Dependency Injection
        public IndexModel(IKundeRepository repository)
        {
            _repo = repository;
        }





        // property til View'et
        public List<Kunde> Kunder { get;  set; }

        public void OnGet()
        {

            //KundeRepository repo = new KundeRepository(true);

            Kunder = _repo.HentAlleKunder();

        }

        public IActionResult OnPost()
        {
            return RedirectToPage("NyKunde");
        }
    }
}