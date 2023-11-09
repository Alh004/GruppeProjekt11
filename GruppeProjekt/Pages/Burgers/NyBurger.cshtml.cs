using System.ComponentModel.DataAnnotations;
using GruppeProjekt.model;
using GruppeProjekt.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace GruppeProjekt.Pages.Burgers;
public class NyBurgersModel : PageModel
{
    private IBurgerRepository _repo;

    public NyBurgersModel(IBurgerRepository repo)
    {
        _repo = repo;
    }

    [BindProperty]
    public int NytBurgerPris { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Der skal være et navn")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
    public string NytBurgerNavn { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Der skal være en størrelse")]
    public string NytBurgerStørrelse { get; set; }

    public string ErrorMessage { get; private set; }

    public void OnGet()
    {
        // If you need to perform any actions when the page is loaded, you can include them here.
    }

    public IActionResult OnPost()
    {
        ErrorMessage = "";
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Burger NyBurger = new Burger(NytBurgerPris, NytBurgerNavn, NytBurgerStørrelse);

        try
        {
            _repo.Tilføj(NyBurger);
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
