using System.Text.Json;
using GruppeProjekt.model;

namespace GruppeProjekt.services;

public class KundeRepositoryJson
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

    public KundeRepositoryJson()
    {
        _katalog = ReadFromJson();
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

    public List<Kunde> HentAlleKunder()
    {
        return _katalog.Values.ToList();
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
    
    /*
     *hjælpe metode til at læste og skrive til en fil i json format
     */

    private const string FILENAME = "KundeRepository.json" ;
        
    private Dictionary<int, Kunde> ReadFromJson()    {
        if (File.Exists(FILENAME))
        {
            StreamReader sr = File.OpenText(FILENAME);
            return JsonSerializer.Deserialize<Dictionary<int, Kunde>>(sr.ReadToEnd());
        }
        else
        {
            return new Dictionary<int, Kunde>();
        }
    }

    private void WriteToJson()

    {
        FileStream fs = new FileStream(FILENAME, FileMode.Create);
        Utf8JsonWriter writer = new Utf8JsonWriter(fs);
        JsonSerializer.Serialize(writer, _katalog);
        fs.Close();
    }

   }
    
