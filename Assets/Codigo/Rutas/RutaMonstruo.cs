using System.Collections.Generic;
using static Constantes;

// bifurcación_mon_0
// bifurcación_mon_1
// bifurcación_mon_2
// bifurcación_mon_3

// mon_0
// mon_1
// mon_2
// mon_3
// mon_4
// mon_5
// mon_6
// mon_7
// mon_8
// mon_9
// mon_10

public class RutaMonstruo : InterfazRuta
{
    private Rutas ruta = Rutas.monstruo;

    private ElementoDialogo CrearBifurcación_monstruo_0()
    {
        var usuario = new RutaUsuario();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_monstruo0_0", usuario.CrearUsuario_7()),
            new ElementoOpcion("opcion_monstruo0_1", CrearMonstruo_2()),
            new ElementoOpcion("opcion_monstruo0_2", CrearMonstruo_3()),
            new ElementoOpcion("opcion_monstruo0_3", CrearMonstruo_4())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_monstruo_1()
    {
        var usuario = new RutaUsuario();
        var sótano = new RutaSotano();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_monstruo1_0", usuario.CrearUsuario_8()),
            new ElementoOpcion("opcion_monstruo1_1", CrearMonstruo_6()),
            new ElementoOpcion("opcion_monstruo1_2", sótano.CrearSótano_0())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_monstruo_2()
    {
        var sótano = new RutaSotano();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_monstruo2_0", CrearMonstruo_7()),
            new ElementoOpcion("opcion_monstruo2_2", sótano.CrearSótano_1()),
            
            // Opción limitada
            new ElementoOpcion("opcion_monstruo2_1", CrearMonstruo_8(), RespuestasClave.monstruoObservado)
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_monstruo_3()
    {
        var autor = new RutaAutor();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_monstruo3_0", CrearMonstruo_9()),

            // Opción limitada
            new ElementoOpcion("opcion_monstruo3_1", CrearMonstruo_10(), RespuestasClave.nombreDado)
        };

        // Preguntas encontradas
        var preguntasEncontradas = SistemaMemoria.ObtenerPreguntas();
        foreach (var pregunta in preguntasEncontradas)
        {
            listaOpciones.Add(new ElementoOpcion(pregunta, autor.CrearAutor_0(pregunta)));
        }

        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    public ElementoDialogo CrearMonstruo_0()
    {
        var usuario = new RutaUsuario();
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_4", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_6", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_7", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo0_10", ruta),

            // Opciones
            usuario.CrearBifurcación_usuario_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearMonstruo_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "monstruo1_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "monstruo1_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo1_19", ruta),

            // Opciones
            CrearBifurcación_monstruo_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "monstruo2_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo2_10", ruta),

            // Siguiente diálogo
            CrearMonstruo_5()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo3_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo3_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo3_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo3_3", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo3_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo3_5", ruta),

            // Siguiente diálogo
            CrearMonstruo_5()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo4_0", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo4_1", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "monstruo4_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "monstruo4_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "monstruo4_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo4_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo4_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo4_7", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo4_8", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo4_9", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo4_10", ruta, NivelEstrés.bajo),

            // Final
            ElementoDialogo.CrearFinal("MONSTRUO_4", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_5()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo5_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo5_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo5_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo5_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo5_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo5_5", ruta),

            // Opciones
            CrearBifurcación_monstruo_1()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_6()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "monstruo6_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_9", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "monstruo6_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo6_18", ruta),

            // Opciones
            CrearBifurcación_monstruo_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_7()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_4", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_6", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_7", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo7_8", ruta, NivelEstrés.bajo),

            // Final
            ElementoDialogo.CrearFinal("MONSTRUO_7", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_8()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo8_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo8_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo8_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo8_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo8_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo8_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo8_6", ruta),

            // Opciones
            CrearBifurcación_monstruo_3()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_9()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_0", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_27", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_28", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_29", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_30", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_31", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_32", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_33", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_34", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_35", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_36", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_37", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo9_38", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_39", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo9_40", ruta, NivelEstrés.bajo),

            // Final
            ElementoDialogo.CrearFinal("MONSTRUO_9", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearMonstruo_10()
    {
        var últimoNombreDado = SistemaMemoria.ObtenerNombreDado();
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_6", ruta),

            // Nombre dado
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, últimoNombreDado, ruta, NivelEstrés.normal, Animaciones.nada, DiálogoEspecial.noTraducible),

            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_26", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_27", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_28", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_29", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo10_30", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "monstruo10_31", ruta, NivelEstrés.bajo),

            // Final
            ElementoDialogo.CrearFinal("MONSTRUO_10", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
