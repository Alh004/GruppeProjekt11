using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using GruppeProjekt.model;

namespace GruppeProjekt.services
{
    public class BurgerRepositoryJson
    {
        // instans felt
        Dictionary<int, Burger> _burgerKatalog;

        // properties
        public Dictionary<int, Burger> BurgerKatalog
        {
            get { return _burgerKatalog; }
            set { _burgerKatalog = value; }
        }

        // konstruktør
        public BurgerRepositoryJson()
        {
            _burgerKatalog = ReadFromJson();
        }

        /*
         * metoder
         */
        public Burger Tilføj(Burger burger)
        {
            if (!_burgerKatalog.ContainsKey(burger.Pris))
            {
                _burgerKatalog.Add(burger.Pris, burger);
                return burger;
            }
            throw new ArgumentException($"Pris {burger.Pris} findes i forvejen");
        }

        public Burger Slet(int pris)
        {
            Burger slettetBurger = HentBurger(pris);
            _burgerKatalog.Remove(pris);
            return slettetBurger;
        }

        public Burger Opdater(Burger burger)
        {
            Burger editBurger = HentBurger(burger.Pris);
            _burgerKatalog[burger.Pris] = burger;
            return burger;
        }

        public Burger HentBurger(int pris)
        {
            if (_burgerKatalog.ContainsKey(pris))
            {
                return _burgerKatalog[pris];
            }
            else
            {
                // opdaget en fejl
                throw new KeyNotFoundException($"Pris {pris} findes ikke");
            }
        }

        public List<Burger> HentAlleBurgere()
        {
            return _burgerKatalog.Values.ToList();
        }
        
        public Burger HentBurger(string Navn)
        {
            Burger resBurger = null;

            foreach (Burger b in _burgerKatalog.Values)
            {
                if (b.Navn == Navn)
                {
                }
            }

            return resBurger;
        }

        public override string ToString()
        {
            String pænTekst = string.Join(", ", _burgerKatalog.Values);
            return $"{{{nameof(BurgerKatalog)}={pænTekst}}}";
        }

        /*
         *hjælpe metode til at læse og skrive til en fil i json format
         */
        private const string FILENAME = "BurgerRepository.json";

        private Dictionary<int, Burger> ReadFromJson()
        {
            if (File.Exists(FILENAME))
            {
                StreamReader sr = File.OpenText(FILENAME);
                return JsonSerializer.Deserialize<Dictionary<int, Burger>>(sr.ReadToEnd());
            }
            else
            {
                return new Dictionary<int, Burger>();
            }
        }

        private void WriteToJson()
        {
            using (FileStream fs = new FileStream(FILENAME, FileMode.Create))
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(fs);
                JsonSerializer.Serialize(writer, _burgerKatalog);
            }
        }
    }
}
