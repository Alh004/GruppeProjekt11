using GruppeProjekt.model;

namespace GruppeProjekt.services

{
    public class KundeRepository:IKundeRepository 
    {
    // instans felt
    Dictionary<int, Kunde> _katalog;

    // properties
    public Dictionary<int, Kunde> Katalog
    {
        get { return _katalog; }
        set { _katalog = value; }
    }

    // konstruktør
    public KundeRepository(bool mockData = false)
    {
        _katalog = new Dictionary<int, Kunde>();


        if (mockData)
        {
            PopulateKundeRepository();
        }
    }

    private void PopulateKundeRepository()
    {
        _katalog.Clear();
        _katalog.Add(1, new Kunde(1, "Ali", "42659793"));
        _katalog.Add(2, new Kunde(2, "Fitah", "11349634"));
        _katalog.Add(3, new Kunde(3, "Khud", "09908973"));
        _katalog.Add(4, new Kunde(4, "Amin", "87426583"));
        _katalog.Add(5, new Kunde(5, "Sal", "11223445"));
    }

    /*
     * metoder
     */
    public Kunde Tilføj(Kunde kunde)
    {
        {
            if (!_katalog.ContainsKey(kunde.KundeNummer))

                _katalog.Add(kunde.KundeNummer, kunde);

            return kunde;
        }
        throw new ArgumentException($"KundeNummer {kunde.KundeNummer} findes i forvejen");

    }
    
    public List<Kunde> HentAlleKunder()
    {
        return _katalog.Values.ToList();
    }


    public Kunde Slet(int kundenummer)
    {
        Kunde slettetKunde = HentKunde(kundenummer);

        _katalog.Remove(kundenummer);

        return slettetKunde;
    }

    public Kunde Opdater(Kunde kunde)
    {
        Kunde editKunde = HentKunde(kunde.KundeNummer);

        _katalog[kunde.KundeNummer] = kunde;

        return kunde;
    }

    public Kunde HentKunde(int kundenummer)
    {
        if (_katalog.ContainsKey(kundenummer))
        {
            return _katalog[kundenummer];
        }
        else
        {
            // opdaget en fejl
            throw new ArgumentException($"KundeNummer {kundenummer} findes i ikke");
        }
    }
    

    public Kunde HentKundeUdFraTlf(string tlf)
    {
        Kunde resKunde = null;

        foreach (Kunde k in _katalog.Values)
        {
            if (k.Tlf == tlf)
            {
                return k;
            }
        }

        return resKunde;
    }

    public override string ToString()
    {
        String pænTekst = String.Join(", ", _katalog.Values);

        return $"{{{nameof(Katalog)}={pænTekst}}}";
    }


    }
}
