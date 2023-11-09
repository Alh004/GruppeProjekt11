using GruppeProjekt.model;

namespace GruppeProjekt.services
{
    public class BurgerRepository : IBurgerRepository
    {
        // instance field
        private Dictionary<int, Burger> _burgerkatalog;

        // properties
        public Dictionary<int, Burger> Katalog
        {
            get { return _burgerkatalog; }
            set { _burgerkatalog = value; }
        }

        // constructor
        public BurgerRepository(bool mockData = false)
        {
            _burgerkatalog = new Dictionary<int, Burger>();

            if (mockData)
            {
                PopulateBurgerRepository();
            }
        }

        private void PopulateBurgerRepository()
        {
            _burgerkatalog.Clear();
            _burgerkatalog.Add(1, new Burger(79, "Big mamma", "Small"));
            _burgerkatalog.Add(2, new Burger(79, "Big papa", "Small"));
            _burgerkatalog.Add(3, new Burger(79, "Mexicano", "Small"));
            _burgerkatalog.Add(4, new Burger(95, "Barbecue", "Large"));
            _burgerkatalog.Add(5, new Burger(87, "American", "Medium"));
        }

        /*
         * methods
         */
        public Burger Tilføj(Burger burger)
        {
            if (!_burgerkatalog.ContainsKey(burger.Pris))
            {
                _burgerkatalog.Add(burger.Pris, burger);
                return burger;
            }

            throw new ArgumentException();
        }

        public List<Burger> HentAlleBurgere()
        {
            return _burgerkatalog.Values.ToList();
        }

        public Burger Slet(int pris)
        {
            Burger slettetBurger = HentBurger(pris);

            _burgerkatalog.Remove(pris);

            return slettetBurger;
        }

        public Burger Opdater(Burger burger)
        {
            Burger editBurger = HentBurger(burger.Pris);

            _burgerkatalog[burger.Pris] = burger;

            return burger;
            
        }

        public Burger HentBurger(int pris)
        {
            if (_burgerkatalog.ContainsKey(pris))
            {
                return _burgerkatalog[pris];
            }


            return null;
        }
        

        public Burger HentBurgerUdFraNavn(string Navn)
        {
            Burger resBurger = null;

            foreach (Burger b in _burgerkatalog.Values)
            {
                if (b.Navn == Navn)
                {
                    return b;
                }
            }

            return resBurger;
        }

        public override string ToString()
        {
            string pænTekst = string.Join(", ", _burgerkatalog.Values);
            return $"{{{nameof(Katalog)}={pænTekst}}}";
        }
    }
}

