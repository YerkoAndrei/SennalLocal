using System.Collections.Generic;
using static Constantes;

// bifurcación_caza_0

// caza_0
// caza_1
// caza_2
// caza_3

public class RutaCaza : InterfazRuta
{
    private Rutas ruta = Rutas.caza;

    private ElementoDialogo CrearBifurcación_caza_0()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_caza0_0", CrearCaza_1()),
            new ElementoOpcion("opcion_caza0_1", CrearCaza_2()),
            new ElementoOpcion("opcion_caza0_2", CrearCaza_3())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    public ElementoDialogo CrearCaza_0()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 0", ruta),

            // Opciones
            CrearBifurcación_caza_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearCaza_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 1", ruta),

            // Final
            ElementoDialogo.CrearFinal("CAZA_1", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearCaza_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 2", ruta),

            // Final
            ElementoDialogo.CrearFinal("CAZA_2", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearCaza_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 3", ruta),

            // Final
            ElementoDialogo.CrearFinal("CAZA_3", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
