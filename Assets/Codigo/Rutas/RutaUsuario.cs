using System.Collections.Generic;
using static Constantes;

// bifurcación_usu_0
// bifurcación_usu_1
// bifurcación_usu_2
// bifurcación_usu_3

// usu_0
// usu_1
// usu_2
// usu_3
// usu_4
// usu_5
// usu_6
// usu_7
// usu_8
// usu_9
// usu_10
// usu_11
// usu_12
// usu_13
// usu_14
// usu_15
// usu_16
// usu_17.1
// usu_17.2
// usu_18

public class RutaUsuario : InterfazRuta
{
    private Rutas ruta = Rutas.usuario;

    public ElementoDialogo CrearBifurcación_usuario_0()
    {
        var monstruo = new RutaMonstruo();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_usuario0_0", CrearUsuario_2()),
            new ElementoOpcion("opcion_usuario0_1", CrearUsuario_3())
        };

        // Opción limitada
        if (SistemaMemoria.ObtenerRespuestaClave(RespuestasClave.peligroExterior))
            listaOpciones.Add(new ElementoOpcion("opcion_usuario0_2", monstruo.CrearMonstruo_1()));

        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_usuario_1()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_usuario1_0", CrearUsuario_4()),
            new ElementoOpcion("opcion_usuario1_2", CrearUsuario_6())
        };

        // Opción limitada
        if (SistemaMemoria.ObtenerRespuestaClave(RespuestasClave.encendedorEncontrado))
            listaOpciones.Add(new ElementoOpcion("opcion_usuario1_1", CrearUsuario_5()));

        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_usuario_2()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_usuario2_0", CrearUsuario_10()),
            new ElementoOpcion("opcion_usuario2_1", CrearUsuario_11()),
            new ElementoOpcion("opcion_usuario2_2", CrearUsuario_12())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_usuario_3()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_usuario3_0", CrearUsuario_14()),
            new ElementoOpcion("opcion_usuario3_1", CrearUsuario_15())
        };

        // Opción limitada
        if (SistemaMemoria.ObtenerRespuestaClave(RespuestasClave.llaveComputador))
            listaOpciones.Add(new ElementoOpcion("opcion_usuario3_2", CrearUsuario_16()));

        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo HacerPregunta()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            // Pregunta guardable
            ElementoDialogo.CrearPregunta(CrearUsuario_17_1(), CrearUsuario_17_2(), TipoDiálogo.pregunta)
        };
        // Siguiente diálogo Positivo/Negativo
        return listaDiálogos.ToArray()[0];
    }

    public ElementoDialogo CrearUsuario_0()
    {
        var monstruo = new RutaMonstruo();
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 0", ruta),

            // Siguiente diálogo
            monstruo.CrearMonstruo_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearUsuario_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 1", ruta),

            // Siguiente diálogo
            CrearUsuario_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 2", ruta),

            // Opciones
            CrearBifurcación_usuario_1()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 3", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_3", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 4", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_4", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_5()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 5", ruta),

            // Opciones
            CrearBifurcación_usuario_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_6()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 6", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_6", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearUsuario_7()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 7", ruta),

            // Siguiente diálogo
            CrearUsuario_9()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearUsuario_8()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 8", ruta),

            // Siguiente diálogo
            CrearUsuario_9()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_9()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 9", ruta),

            // Opciones
            CrearBifurcación_usuario_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_10()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 10", ruta),

            // Siguiente diálogo
            CrearUsuario_13()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_11()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 11", ruta),

            // Siguiente diálogo
            CrearUsuario_13()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_12()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 12", ruta),

            // Siguiente diálogo
            CrearUsuario_13()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_13()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 13", ruta),

            // Opciones
            CrearBifurcación_usuario_3()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_14()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN USUARIO", ruta, NivelEstrés.alto, Animaciones.llegaUsuario),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_14", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_15()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 15", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_15", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_16()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 16", ruta),

            // Siguiente diálogo
            HacerPregunta()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_17_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 17.1", ruta),

            // Siguiente diálogo
            CrearUsuario_18()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_17_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 17.2", ruta),

            // Siguiente diálogo
            CrearUsuario_18()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_18()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 18", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_18", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
