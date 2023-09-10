using System.Collections.Generic;
using static Constantes;

// bifurcación_ope_0
// bifurcación_ope_1
// bifurcación_ope_2
// bifurcación_ope_3

// ope_0
// ope_1
// ope_3
// ope_4
// ope_5
// ope_6
// ope_7
// ope_8
// ope_9.1
// ope_9.2
// ope_10

public class RutaOperador : InterfazRuta
{
    private Rutas ruta = Rutas.operador;

    private ElementoDialogo CrearBifurcación_operador_0()
    {
        var usuario = new RutaUsuario();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_operador0_0", CrearOperador_3()),
            new ElementoOpcion("opcion_operador0_1", usuario.CrearUsuario_0())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_operador_1()
    {
        var usuario = new RutaUsuario();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_operador1_0", CrearOperador_4()),
            new ElementoOpcion("opcion_operador1_1", CrearOperador_5()),
            new ElementoOpcion("opcion_operador1_2", usuario.CrearUsuario_1())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_operador_2()
    {
        var caza = new RutaCaza();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_operador2_0", caza.CrearCaza_0()),
            new ElementoOpcion("opcion_operador2_1", CrearOperador_7()),
            new ElementoOpcion("opcion_operador2_2", CrearOperador_6())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_operador_3()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_operador3_0", CrearOperador_8()),
            new ElementoOpcion("opcion_operador3_1", DarNombre())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo DarNombre()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            // Pregunta nombre
            ElementoDialogo.CrearPregunta(CrearOperador_9_1(), CrearOperador_9_2(), TipoDiálogo.nombre)
        };
        // Siguiente diálogo Positivo/Negativo
        return listaDiálogos.ToArray()[0];
    }

    public ElementoDialogo CrearOperador_0()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_15", ruta),

            // Siguiente diálogo
            CrearOperador_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearOperador_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador1_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador1_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador1_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador1_4", ruta),

            // Siguiente diálogo
            CrearOperador_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_10", ruta),

            // Opciones
            CrearBifurcación_operador_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_8", ruta),

            // Opciones
            CrearBifurcación_operador_1()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_13", ruta),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_4", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_5()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_27", ruta),

            // Opciones
            CrearBifurcación_operador_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_6()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_17", ruta),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_6", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_7()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_27", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_28", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_29", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_30", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_31", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_32", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_33", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_34", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_35", ruta),

            // Opciones
            CrearBifurcación_operador_3()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_8()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_27", ruta),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_8", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_9_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_9_1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN OPERADOR", ruta, NivelEstrés.alto, Animaciones.miraManos),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_9_1_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_9_1_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_9_1_3", ruta),

            // Final
            CrearOperador_10()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_9_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_9_2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_9_2_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_9_2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_9_2_3", ruta),

            // Final
            CrearOperador_10()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_10()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador_10_27", ruta),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_10", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
