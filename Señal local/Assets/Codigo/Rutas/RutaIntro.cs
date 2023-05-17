﻿using System.Collections.Generic;
using static Constantes;

// bifurcación_intro_0
// bifurcación_intro_1

// intro_0
// intro_1
// intro_2
// intro_3
// intro_4
// intro_5

public class RutaIntro : InterfazRuta
{
    private Rutas ruta = Rutas.intro;

    public ElementoDialogo CrearPrimerDiálogo()
    {
        return CrearIntro_0()[0];
    }

    public ElementoDialogo CrearBifurcación_intro_0()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("¿Hay algo que recuerdes?", CrearIntro_1()[0]));
        listaOpciones.Add(new ElementoOpcion("¿Qué objetos tienes?", CrearIntro_2()[0]));
        listaOpciones.Add(new ElementoOpcion("¿Qué ves a tu alrededor?", CrearIntro_3()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_intro_1()
    {
        var operador = new RutaOperador();
        var monstruo = new RutaMonstruo();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Mira por la ventana", operador.CrearOperador_0()[0]));
        listaOpciones.Add(new ElementoOpcion("Busca a alguien", operador.CrearOperador_1()[0]));
        listaOpciones.Add(new ElementoOpcion("Intenta abrir la puerta", CrearIntro_5()[0]));
        listaOpciones.Add(new ElementoOpcion("Sube la escalera", monstruo.CrearMonstruo_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] CrearIntro_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 0", ruta, NivelEstrés.normal));

        // Efectos
        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.bajo);
        ControladorRadio.CambiarNombreRuta(Rutas.intro);

        // Opciones
        listaDiálogos.Add(CrearBifurcación_intro_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearIntro_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 1", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearIntro_4()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearIntro_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 2", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearIntro_4()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearIntro_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 3", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearIntro_4()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearIntro_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 4", ruta, NivelEstrés.normal));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_intro_1());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearIntro_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "INTRO 5", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("INTRO_5", TipoFinal.muerte, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
