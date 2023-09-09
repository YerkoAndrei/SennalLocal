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

    public ElementoDialogo CrearBifurcación_monstruo_0()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo0_0", usuario.CrearUsuario_7()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo0_1", CrearMonstruo_2()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo0_2", CrearMonstruo_3()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo0_3", CrearMonstruo_4()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_1()
    {
        var usuario = new RutaUsuario();
        var sótano = new RutaSotano();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo1_0", usuario.CrearUsuario_8()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo1_1", CrearMonstruo_6()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo1_2", sótano.CrearSótano_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_2()
    {
        var sótano = new RutaSotano();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo2_0", CrearMonstruo_7()[0]));
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo2_2", sótano.CrearSótano_1()[0]));

        // Opción limitada
        if (SistemaMemoria.ObtenerRespuestaClave(RespuestasClave.monstruoObservado))
            listaOpciones.Add(new ElementoOpcion("opcion_monstruo2_1", CrearMonstruo_8()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_3()
    {
        var autor = new RutaAutor();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("opcion_monstruo3_0", CrearMonstruo_9()[0]));

        // Opción limitada
        if (SistemaMemoria.ObtenerRespuestaClave(RespuestasClave.nombreDado))
            listaOpciones.Add(new ElementoOpcion("opcion_monstruo3_1", ResponderNombre()[0]));

        // Preguntas encontradas
        var preguntasEncontradas = SistemaMemoria.ObtenerPreguntas();
        foreach(var pregunta in preguntasEncontradas)
        {
            listaOpciones.Add(new ElementoOpcion(pregunta, autor.CrearAutor_0()[0]));
        }

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] ResponderNombre()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        var últimoNombreDado = SistemaMemoria.ObtenerNombreDado();
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.monstruo, últimoNombreDado, ruta));

        // Siguiente diálogo
        listaDiálogos.Add(CrearMonstruo_10()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_0()
    {
        var usuario = new RutaUsuario();
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 0", ruta));

        // Opciones
        listaDiálogos.Add(usuario.CrearBifurcación_usuario_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 1", ruta));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 2", ruta));

        // Siguiente diálogo
        listaDiálogos.Add(CrearMonstruo_5()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 3", ruta));

        // Siguiente diálogo
        listaDiálogos.Add(CrearMonstruo_5()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 4", ruta));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("MONSTRUO_4", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 5", ruta));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_1());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_6()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 6", ruta));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_2());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_7()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 7", ruta));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("MONSTRUO_7", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_8()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 8", ruta));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_3());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_9()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 9", ruta));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("MONSTRUO_9", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_10()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 10", ruta));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("MONSTRUO_10", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
