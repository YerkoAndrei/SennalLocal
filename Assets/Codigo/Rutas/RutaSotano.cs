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
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano0_16", ruta),

            // Siguiente diálogo
            CrearSótano_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearSótano_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano1_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano1_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano1_3", ruta),

            // Siguiente diálogo
            CrearSótano_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearSótano_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano2_12", ruta),

            // Opciones
            CrearBifurcación_Sótano_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearSótano_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano3_9", ruta),

            // Final
            ElementoDialogo.CrearFinal("SÓTANO_4", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearSótano_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano4_23", ruta),

            // Final
            ElementoDialogo.CrearFinal("SÓTANO_4", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
