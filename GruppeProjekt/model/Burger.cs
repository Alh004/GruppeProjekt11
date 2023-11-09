namespace GruppeProjekt.model;

public class Burger
{
    
    /*
     * Instans felter
     */
    private int _pris; // rename _kundeNummer to _pris
    private string _navn; // keep _navn unchanged
    private string _størrelse; // rename _tlf to _størrelse

    /*
     * Properties
     */
    public int Pris
    {
        get { return _pris; }
        set { _pris = value; }
    }

    public string Navn
    {
        get { return _navn; }
        set { _navn = value; }
    }

    public string Størrelse
    {
        get { return _størrelse; }
        set { _størrelse = value; }
    }

    /*
     * Constructor
     */
    public Burger()
    {
        _pris = 0;
        _navn = "";
        _størrelse = "";
    }
    public Burger(int pris, string navn, string størrelse)
    {
        _pris = pris;
        _navn = navn;
        _størrelse = størrelse;
    }

    public override string ToString()
    {
        return $"{{{nameof(Pris)}={Pris}, {nameof(Navn)}={Navn}, {nameof(Størrelse)}={Størrelse}}}";
    }
}

