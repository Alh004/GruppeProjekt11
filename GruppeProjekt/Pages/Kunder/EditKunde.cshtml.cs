using System.ComponentModel.DataAnnotations;
using GruppeProjekt.model;
using GruppeProjekt.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GruppeProjekt.Pages.Kunder       
{
    public class EditKundeModel : PageModel
    {
        private IKundeRepository _repo;
        
        public EditKundeModel(IKundeRepository repo)
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
        public bool Error { get; private set; }

        public void OnGet(int nummer)
        {
            ErrorMessage = "";
            Error = false;

            try
            {
                Kunde kunde = _repo.HentKunde(nummer);

                NytKundeNummer = kunde.KundeNummer;
                NytKundeNavn = kunde.Navn;
                NytKundetlf = kunde.Tlf;
            }
            catch (KeyNotFoundException knfe)
            {
                ErrorMessage = knfe.Message;
                Error = true;
            }
        }
        
        public IActionResult OnPost()
        {
            if ( !ModelState.IsValid )
            {
                return Page();
            }

            Kunde kunde = _repo.HentKunde(NytKundeNummer);
            kunde.Navn = NytKundeNavn;
            kunde.Tlf = NytKundetlf;

            return RedirectToPage("Index");
        }



        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
       
    }
        
    }
