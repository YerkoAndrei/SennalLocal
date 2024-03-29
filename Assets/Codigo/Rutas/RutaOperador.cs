﻿using System.Collections.Generic;
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
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_1", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_2", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador0_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador0_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador0_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador0_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador0_16", ruta),

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
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador1_1", ruta),
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
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_1", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador2_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador2_7", ruta),
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
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador3_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador3_5", ruta, NivelEstrés.alto),
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
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador4_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_6", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador4_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador4_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_10", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_11", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_12", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador4_13", ruta, NivelEstrés.muerto),

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
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_3", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_4", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_6", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador5_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador5_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador5_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador5_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador5_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador5_26", ruta),

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
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador6_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_11", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_12", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_13", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_14", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_15", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_16", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador6_17", ruta, NivelEstrés.muerto),

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
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador7_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador7_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador7_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_12", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_22", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_23", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_24", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_25", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_26", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_27", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_28", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_29", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador7_30", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_31", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_32", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador7_33", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador7_34", ruta),

            // Opciones
            CrearBifurcación_operador_3()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_8()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador8_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador8_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_8", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_9", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_10", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador8_12", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador8_13", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador8_20", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador8_21", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_22", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "operador8_23", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "operador8_24", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "operador8_25", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_26", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_27", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador8_28", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "operador8_29", ruta, NivelEstrés.bajo),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_8", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_9_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador9_1_0", ruta, NivelEstrés.normal, Animaciones.nada, DiálogoEspecial.conFormato),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN OPERADOR", ruta, NivelEstrés.alto, Animaciones.miraManos),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador9_1_1", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador9_1_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador9_1_3", ruta),

            // Final
            CrearOperador_10()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_9_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador9_2_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador9_2_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador9_2_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador_9_2_3", ruta, NivelEstrés.alto),

            // Final
            CrearOperador_10()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_10()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador10_0", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador10_2", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador10_3", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_4", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_5", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador10_6", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador10_7", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_10", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_11", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_12", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador10_14", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador10_15", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_22", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_23", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_24", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.sobreviviente, "operador10_25", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador10_26", ruta, NivelEstrés.gritando),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_27", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "operador10_28", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "operador10_29", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "operador10_30", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_31", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_32", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_33", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_34", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "operador10_35", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_36", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "operador10_37", ruta, NivelEstrés.bajo),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_10", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
