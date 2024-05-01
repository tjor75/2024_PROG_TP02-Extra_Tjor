class Superheroe {
    public string Nombre {get; private set;}
    public string Ciudad {get; private set;}
    public double Peso {get; private set;}
    public double Fuerza {get; private set;}
    public double Velocidad {get; private set;}

    public Superheroe(string nombre, string ciudad, double peso, double fuerza, double velocidad)
    {
        Nombre = nombre;
        Ciudad = ciudad;
        Peso = peso;
        Fuerza = fuerza;
        Velocidad = velocidad;
    }
    
    public double ObtenerSkill()
    {
        Random random = new Random();
        return (Velocidad * 0.6) + (Fuerza * 0.8) + random.Next(1, 11);
    }
}