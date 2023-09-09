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
// ope_9

public class RutaOperador : InterfazRuta
{
    private Rutas ruta = Rutas.operador;

    public ElementoDialogo CrearBifurcación_operador_0()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("opcion_operador0_0", CrearOperador_3()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_operador0_1", usuario.CrearUsuario_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_1()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("opcion_operador1_0", CrearOperador_4()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_operador1_1", CrearOperador_5()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_operador1_2", usuario.CrearUsuario_1()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_2()
    {
        var caza = new RutaCaza();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("opcion_operador2_0", caza.CrearCaza_0()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_operador2_1", CrearOperador_7()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_operador2_2", CrearOperador_6()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_3()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("opcion_operador3_0", CrearOperador_8()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_operador3_1", DarNombre()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] DarNombre()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Pregunta
        listaDiálogos.Add(ElementoDialogo.CrearPregunta(CrearOperador_9_1()[0], CrearOperador_9_2()[0], TipoDiálogo.nombre));

        // Siguiente diálogo Neutro
        return listaDiálogos.ToArray();
    }

    public ElementoDialogo[] CrearOperador_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 0", ruta));

        // Siguiente diálogo
        listaDiálogos.Add(CrearOperador_2()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 1", ruta));

        // Siguiente diálogo
        listaDiálogos.Add(CrearOperador_2()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 2", ruta));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 3", ruta));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_1());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 4", ruta));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("OPERADOR_4", TipoFinal.muerte, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 5", ruta));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_2());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_6()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 6", ruta));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("OPERADOR_6", TipoFinal.muerte, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_7()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 7", ruta));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_3());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_8()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 8", ruta));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("OPERADOR_8", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_9_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN OPERADOR", ruta, NivelEstrés.alto, Animaciones.miraManos));
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 9.1", ruta));

        // Final
        listaDiálogos.Add(CrearOperador_10()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_9_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 9.2", ruta));

        // Final
        listaDiálogos.Add(CrearOperador_10()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_10()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 10", ruta));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("OPERADOR_10", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
