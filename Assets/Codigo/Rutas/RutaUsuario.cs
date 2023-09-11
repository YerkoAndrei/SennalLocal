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
            new ElementoOpcion("opcion_usuario0_1", CrearUsuario_3()),
            
            // Opción limitada
            new ElementoOpcion("opcion_usuario0_2", monstruo.CrearMonstruo_1(), RespuestasClave.peligroExterior)
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_usuario_1()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_usuario1_0", CrearUsuario_4()),
            new ElementoOpcion("opcion_usuario1_2", CrearUsuario_6()),
            
            // Opción limitada
            new ElementoOpcion("opcion_usuario1_1", CrearUsuario_5(), RespuestasClave.encendedorEncontrado)
        };
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
            new ElementoOpcion("opcion_usuario3_1", CrearUsuario_15()),

            // Opción limitada
            new ElementoOpcion("opcion_usuario3_2", CrearUsuario_16(), RespuestasClave.llaveComputador)
        };
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
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario0_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario0_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario0_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario0_11", ruta),

            // Siguiente diálogo
            monstruo.CrearMonstruo_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearUsuario_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario1_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario1_2", ruta),

            // Siguiente diálogo
            CrearUsuario_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario2_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario2_12", ruta),

            // Opciones
            CrearBifurcación_usuario_1()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario3_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario3_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario3_14", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_3", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario4_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario4_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario4_15", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_4", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_5()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario5_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario5_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario5_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario5_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario5_4", ruta),

            // Opciones
            CrearBifurcación_usuario_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_6()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario6_12", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_6", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearUsuario_7()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario7_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario7_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario7_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario7_3", ruta),

            // Siguiente diálogo
            CrearUsuario_9()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearUsuario_8()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario8_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario8_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario8_12", ruta),

            // Siguiente diálogo
            CrearUsuario_9()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_9()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario9_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario9_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario9_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario9_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario9_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario9_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario9_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario9_7", ruta),

            // Opciones
            CrearBifurcación_usuario_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_10()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario10_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario10_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario10_11", ruta),

            // Siguiente diálogo
            CrearUsuario_13()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_11()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario11_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario11_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario11_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario11_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario11_4", ruta),

            // Siguiente diálogo
            CrearUsuario_13()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_12()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario12_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario12_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario12_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario12_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario12_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario12_19", ruta),

            // Siguiente diálogo
            CrearUsuario_13()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_13()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario13_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario13_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario13_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario13_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario13_4", ruta),

            // Opciones
            CrearBifurcación_usuario_3()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_14()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario14_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario14_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario14_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario14_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario14_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario14_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario14_27", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_28", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario14_29", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario14_30", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN usuario", ruta, NivelEstrés.alto, Animaciones.llegaUsuario),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_14", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_15()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario15_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_27", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_28", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_29", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario15_30", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_31", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_32", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_33", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_34", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_35", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_36", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_37", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_38", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario15_39", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_15", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_16()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario16_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario16_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario16_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario16_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario16_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario16_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_27", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.computador, "usuario16_28", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.computador, "usuario16_29", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.computador, "usuario16_30", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_31", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_32", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario16_33", ruta),

            // Siguiente diálogo
            HacerPregunta()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_17_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.computador, "usuario17_1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.computador, "usuario17_1_1", ruta),

            // Siguiente diálogo
            CrearUsuario_18()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_17_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.computador, "usuario17_2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.computador, "usuario17_2_1", ruta),

            // Siguiente diálogo
            CrearUsuario_18()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearUsuario_18()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario18_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "usuario18_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario18_20", ruta),

            // Final
            ElementoDialogo.CrearFinal("USUARIO_18", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
