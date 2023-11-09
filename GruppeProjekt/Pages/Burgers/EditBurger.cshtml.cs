using System.ComponentModel.DataAnnotations;
using GruppeProjekt.model;
using GruppeProjekt.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace GruppeProjekt.Pages.Burgere;
public class EditBurgerModel : PageModel
{
    private IBurgerRepository _repo;

    public EditBurgerModel(IBurgerRepository repo)
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

    public void OnGet(int pris)
    {
        ErrorMessage = "";

        try
        {
            Burger burger = _repo.HentBurger(pris);
            NytBurgerPris = burger.Pris;
            NytBurgerNavn = burger.Navn;
            NytBurgerStørrelse = burger.Størrelse;
        }
        catch (KeyNotFoundException)
        {
            ErrorMessage = "Burger not found.";
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Burger burger = _repo.HentBurger(NytBurgerPris);
        burger.Navn = NytBurgerNavn;
        burger.Størrelse = NytBurgerStørrelse;

        return RedirectToPage("Index");
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("Index");
    }
}
