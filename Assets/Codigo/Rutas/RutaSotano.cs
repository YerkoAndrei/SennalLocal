using System.Collections.Generic;
using static Constantes;

// bifurcación_sot_0

// sot_0
// sot_1
// sot_2
// sot_3
// sot_4

public class RutaSotano : InterfazRuta
{
    private Rutas ruta = Rutas.sótano;

    private ElementoDialogo CrearBifurcación_Sótano_0()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_sotano0_0", CrearSótano_3()),
            new ElementoOpcion("opcion_sotano0_1", CrearSótano_4())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    public ElementoDialogo CrearSótano_0()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 0", ruta),

            // Siguiente diálogo
            CrearSótano_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearSótano_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 1", ruta),

            // Siguiente diálogo
            CrearSótano_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearSótano_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 2", ruta),

            // Opciones
            CrearBifurcación_Sótano_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearSótano_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 3", ruta),

            // Final
            ElementoDialogo.CrearFinal("SÓTANO_4", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearSótano_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 4", ruta),

            // Final
            ElementoDialogo.CrearFinal("SÓTANO_4", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
