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

public class RutaUsuario : InterfazRuta
{
    private Rutas ruta = Rutas.usuario;

    public ElementoDialogo CrearBifurcación_usuario_0()
    {
        var monstruo = new RutaMonstruo();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("¡Corre!", CrearUsuario_2()[0]));
        listaOpciones.Add(new ElementoOpcion("Alejate despacio", CrearUsuario_3()[0]));
        listaOpciones.Add(new ElementoOpcion("Intenta verlo mejor", monstruo.CrearMonstruo_1()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_usuario_1()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Busca un interruptor a tientas", CrearUsuario_4()[0]));
        listaOpciones.Add(new ElementoOpcion("Usa tu encendedor", CrearUsuario_5()[0]));
        listaOpciones.Add(new ElementoOpcion("Recoje la varilla", CrearUsuario_6()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_usuario_2()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("¿Qué ves en la habitación?", CrearUsuario_10()[0]));
        listaOpciones.Add(new ElementoOpcion("Busca una puerta", CrearUsuario_11()[0]));
        listaOpciones.Add(new ElementoOpcion("Busca algo útil", CrearUsuario_12()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_usuario_3()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Busca un lugar tranquilo", CrearUsuario_14()[0]));
        listaOpciones.Add(new ElementoOpcion("Quédate ahi", CrearUsuario_15()[0]));
        listaOpciones.Add(new ElementoOpcion("Usa la llave", CrearUsuario_18()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] HacerPregunta()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Pregunta
        listaDiálogos.Add(ElementoDialogo.CrearPregunta());

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_19()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_0()
    {
        var monstruo = new RutaMonstruo();
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 0", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(monstruo.CrearMonstruo_0()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 1", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_0()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 2", ruta, NivelEstrés.normal));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_1());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 3", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("USUARIO_3", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 4", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("USUARIO_4", TipoFinal.muerte, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 5", ruta, NivelEstrés.normal));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_2());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_6()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 6", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("USUARIO_6", TipoFinal.muerte, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_7()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 7", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_9()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_8()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 8", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_9()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_9()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 9", ruta, NivelEstrés.normal));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_2());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_10()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 10", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_13()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_11()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 11", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_13()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_12()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 12", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_13()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_13()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 13", ruta, NivelEstrés.normal));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_3());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_14()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 14", ruta, NivelEstrés.normal));
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN USUARIO", ruta, NivelEstrés.alto, Animaciones.LlegaUsuario));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("USUARIO_14", TipoFinal.muerte, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_15()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 15", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_16()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_16()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 16", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_17()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_17()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 17", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("USUARIO_17", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_18()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 18", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(HacerPregunta()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_19()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 19", ruta, NivelEstrés.normal));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_20()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_20()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "USUARIO 20", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("USUARIO_20", TipoFinal.muerte, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
