using System.ComponentModel.DataAnnotations;
using GruppeProjekt.model;
using GruppeProjekt.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GruppeProjekt.Pages.Kunder
{
    public  class NyKundeModel : PageModel
    {
        private IKundeRepository _repo;

        public NyKundeModel(IKundeRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public int NytKundeNummer { get; set; }



        [BindProperty]
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
        public string NytKundeNavn { get; set; }



        [BindProperty]
        [Required(ErrorMessage = "Der skal være et Nummer")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Der skal være mindst otte tal i et nummer")]
        public string NytKundetlf { get; set; }

        public string ErrorMessage { get; private set; }


        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            ErrorMessage = "";
            if ( !ModelState.IsValid)
            {
                return Page();
            }
            Kunde nyKunde = new Kunde(NytKundeNummer, NytKundeNavn, NytKundetlf);
            try
            {
                //KundeRepository repo = new KundeRepository(true);
                _repo.Tilføj(nyKunde);
            }
            catch (ArgumentException ae)
            {
                ErrorMessage = ae.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
    }