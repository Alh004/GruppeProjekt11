using System.Collections.Generic;

namespace GruppeProjekt.model
{
    public interface IBurgerRepository
    {
        public Dictionary<int, Burger> Katalog { get; set; }
        List<Burger> HentAlleBurgere();
        Burger HentBurger(int pris);
        Burger Opdater(Burger burger);
        Burger Slet(int pris);
        Burger Tilføj(Burger burger);
    }
}