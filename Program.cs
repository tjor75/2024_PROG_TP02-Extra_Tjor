const int OP_DESDE = 1;
const int OP_HASTA = 4;
const int OP_CARGAR_SUPERHEROE1 = 1;
const int OP_CARGAR_SUPERHEROE2 = 2;
const int OP_CARGAR_COMPETIR = 3;
const int OP_SALIR = 4;
const double FUERZA_MIN = 1;
const double FUERZA_MAX = 100;
const double VELOCIDAD_MIN = 1;
const double VELOCIDAD_MAX = 100;
const double PUNTOS_AMPLIA_DIFERENCIA = 30;
const double PUNTOS_MUY_PAREJO = 10;
int opcion;
double skill1;
double skill2;
double moduloDiferenciaPuntos;
Superheroe? superheroe1 = null;
Superheroe? superheroe2 = null;
Superheroe ganador;


string ObtenerCadena(string mensaje)
{
    Console.Write(mensaje);
    return Console.ReadLine();
}
int ObtenerEntero(string mensaje)
{
    int ingreso;
    bool esEntero = int.TryParse(ObtenerCadena(mensaje), out ingreso);
    while (!esEntero)
        esEntero = int.TryParse(ObtenerCadena("Error: ingrese un entero.\n" + mensaje), out ingreso);
    return ingreso;
}
int ObtenerEnteroEntre(string mensaje, int min, int max)
{
    int ingreso = ObtenerEntero(mensaje);
    while (ingreso < min || ingreso > max)
        ingreso = ObtenerEntero(mensaje);
    return ingreso;
}
double ObtenerReal(string mensaje)
{
    double ingreso;
    bool esEntero = double.TryParse(ObtenerCadena(mensaje), out ingreso);
    while (!esEntero)
        esEntero = double.TryParse(ObtenerCadena("Error: ingrese un real.\n" + mensaje), out ingreso);
    return ingreso;
}
double ObtenerRealEntre(string mensaje, double min, double max)
{
    double ingreso = ObtenerReal(mensaje);
    while (ingreso < min || ingreso > max)
        ingreso = ObtenerReal("Error: ingrese un real entre " + min + " y " + max + ".\n" + mensaje);
    return ingreso;
}
double ObtenerRealDesde(string mensaje, double min)
{
    double ingreso = ObtenerReal(mensaje);
    while (ingreso < min)
        ingreso = ObtenerReal("Error: ingrese un real mayor o igual a " + min + ".\n" + mensaje);
    return ingreso;
}

Superheroe ObtenerSuperheroe(double fuerzaMin, double fuerzaMax, double velocidadMin, double velocidadMax)
{
    double peso;
    double fuerza;
    double velocidad;
    string nombre;
    string ciudad;

    fuerza = ObtenerRealEntre("Obtener fuerza (N): ", fuerzaMin, fuerzaMax);
    nombre = ObtenerCadena("Obtener nombre: ");
    ciudad = ObtenerCadena("Obtener ciudad: ");
    peso = ObtenerRealDesde("Obtener peso (kg): ", 0);
    velocidad = ObtenerRealEntre("Obtener velocidad (km/h): ", velocidadMin, velocidadMax);

    return new Superheroe(nombre, ciudad, peso, fuerza, velocidad);
}

double HacerModulo(double num)
{
    double modulo = num;
    if (modulo < 0)
        modulo = num * (-1);
    return modulo;
}

Superheroe CalcularGanador(Superheroe superheroe1, Superheroe superheroe2, double skill1, double skill2)
{
    double diferencia = skill1 - skill2;
    Superheroe ganador;
    if (diferencia >= 0)
        ganador = superheroe1;
    else
        ganador = superheroe2;
    return ganador;
}


do
{
    Console.WriteLine("1. Cargar Datos Superhéroe 1\n" +
        "2. Cargar Datos Superhéroe 2\n" +
        "3. Competir!\n" +
        "4. Salir");
    
    opcion = ObtenerEnteroEntre("> ", OP_DESDE, OP_HASTA);

    switch (opcion)
    {
        case OP_CARGAR_SUPERHEROE1:
            superheroe1 = ObtenerSuperheroe(FUERZA_MIN, FUERZA_MAX, VELOCIDAD_MIN, VELOCIDAD_MAX);
            Console.WriteLine("Se ha creado el superhéroe " + superheroe1.Nombre);
            break;

        case OP_CARGAR_SUPERHEROE2:
            superheroe2 = ObtenerSuperheroe(FUERZA_MIN, FUERZA_MAX, VELOCIDAD_MIN, VELOCIDAD_MAX);
            Console.WriteLine("Se ha creado el superhéroe " + superheroe2.Nombre);
            break;

        case OP_CARGAR_COMPETIR:
            if (superheroe1 != null && superheroe2 != null)
            {
                skill1 = superheroe1.ObtenerSkill();
                skill2 = superheroe2.ObtenerSkill();
                moduloDiferenciaPuntos = HacerModulo(skill1 - skill2);
                ganador = CalcularGanador(superheroe1, superheroe2, skill1, skill2);

                if (moduloDiferenciaPuntos >= PUNTOS_AMPLIA_DIFERENCIA)
                    Console.WriteLine("Ganó " + ganador.Nombre + " por amplia diferencia");
                else if (moduloDiferenciaPuntos >= PUNTOS_MUY_PAREJO)
                    Console.WriteLine("Ganó " + ganador.Nombre + ". ¡Fue muy parejo!");
                else
                    Console.WriteLine("Ganó " + ganador.Nombre + ". ¡No le sobró nada!");
                
                Console.WriteLine("(" + skill1 + " vs " + skill2 + ")");
            }
            else
                Console.WriteLine("Error: Superhéroe 1/2 no fue registrado. Por favor, creelo y vuelva a seleccionar esta opción.");
            break;
    }
} while(opcion != OP_SALIR);