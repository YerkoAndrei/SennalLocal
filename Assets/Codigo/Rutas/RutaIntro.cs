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
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro0_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro0_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro0_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro0_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro0_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro0_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro0_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro0_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro0_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro0_9", ruta),

            // Opciones
            CrearBifurcación_intro_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro1_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro1_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro1_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro1_4", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro1_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro1_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro1_7", ruta),

            // Siguiente diálogo
            CrearIntro_4()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro2_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro2_3", ruta),

            // Siguiente diálogo
            CrearIntro_4()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro3_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro3_1", ruta),

            // Siguiente diálogo
            CrearIntro_4()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro4_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro4_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_5", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro4_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro4_12", ruta),

            // Opciones
            CrearBifurcación_intro_1()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearIntro_5()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_4", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_6", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_7", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_8", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_9", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro5_10", ruta, NivelEstrés.muerto),

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
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro6_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro6_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro6_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro6_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro6_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro6_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro6_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "intro6_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro6_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro6_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "intro6_10", ruta),

            // Siguiente diálogo
            monstruo.CrearMonstruo_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
