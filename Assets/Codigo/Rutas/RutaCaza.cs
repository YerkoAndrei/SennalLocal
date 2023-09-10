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
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza0_17", ruta),

            // Opciones
            CrearBifurcación_caza_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearCaza_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza1_18", ruta),

            // Final
            ElementoDialogo.CrearFinal("CAZA_1", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearCaza_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza2_16", ruta),

            // Final
            ElementoDialogo.CrearFinal("CAZA_2", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearCaza_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "caza3_15", ruta),

            // Final
            ElementoDialogo.CrearFinal("CAZA_3", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
