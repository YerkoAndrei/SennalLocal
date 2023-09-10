using System.Collections.Generic;
using static Constantes;

// bifurcación_intro_0
// bifurcación_intro_1

// intro_0
// intro_1
// intro_2
// intro_3
// intro_4
// intro_5
// intro_6

public class RutaIntro : InterfazRuta
{
    private Rutas ruta = Rutas.intro;

    private ElementoDialogo CrearBifurcación_intro_0()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_intro0_0", CrearIntro_1()),
            new ElementoOpcion("opcion_intro0_1", CrearIntro_2()),
            new ElementoOpcion("opcion_intro0_2", CrearIntro_3())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_intro_1()
    {
        var operador = new RutaOperador();

        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_intro1_0", operador.CrearOperador_0()),
            new ElementoOpcion("opcion_intro1_1", operador.CrearOperador_1()),
            new ElementoOpcion("opcion_intro1_2", CrearIntro_5()),
            new ElementoOpcion("opcion_intro1_3", CrearIntro_6())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    public ElementoDialogo CrearIntro_0()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 0", ruta),

            // Opciones
            CrearBifurcación_intro_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 1", ruta),

            // Siguiente diálogo
            CrearIntro_4()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 2", ruta),

            // Siguiente diálogo
            CrearIntro_4()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 3", ruta),

            // Siguiente diálogo
            CrearIntro_4()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 4", ruta),

            // Opciones
            CrearBifurcación_intro_1()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_5()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 5", ruta),

            // Final
            ElementoDialogo.CrearFinal("INTRO_5", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_6()
    {
        var monstruo = new RutaMonstruo();
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 6", ruta),

            // Siguiente diálogo
            monstruo.CrearMonstruo_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
