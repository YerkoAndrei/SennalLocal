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
    public ElementoDialogo CrearBifurcación_usuario_0()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("¡Corre!", CrearUsuario_1()[0]));
        listaOpciones.Add(new ElementoOpcion("Alejate despacio", CrearUsuario_2()[0]));
        listaOpciones.Add(new ElementoOpcion("Intenta verlo mejor", IntentarVerMonstruo()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_usuario_1()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Busca un interruptor a tientas", CrearUsuario_3()[0]));
        listaOpciones.Add(new ElementoOpcion("Usa tu encendedor", CrearUsuario_4()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_usuario_2()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("¿Qué ves en la habitación?", CrearUsuario_7()[0]));
        listaOpciones.Add(new ElementoOpcion("Busca una puerta", CrearUsuario_8()[0]));
        listaOpciones.Add(new ElementoOpcion("Busca algo útil", CrearUsuario_9()[0]));
        listaOpciones.Add(new ElementoOpcion("Acerca tu encendedor", CrearUsuario_10()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_usuario_3()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Busca un lugar tranquilo", CrearUsuario_12()[0]));
        listaOpciones.Add(new ElementoOpcion("Quédate ahi", CrearUsuario_13()[0]));
        listaOpciones.Add(new ElementoOpcion("Usa la llave", CrearUsuario_14()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] IntentarVerMonstruo()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "0"));

        // Siguiente diálogo
        //if
        //listaDiálogos.Add(CrearUsuario_0()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] HacerPregunta()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "preparación"));

        // Pregunta
        listaDiálogos.Add(ElementoDialogo.CrearPregunta(Personajes.operador, "pregunta"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_15()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_0()
    {
        var monstruo = new RutaMonstruo();
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "0"));

        // Siguiente diálogo
        listaDiálogos.Add(monstruo.CrearMonstruo_0()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "1"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_1());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "2"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_1());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "3"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.muerte));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "4"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_2());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "5"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_6()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_6()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "6"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_2());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_7()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "7"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_11()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_8()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "8"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_11()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_9()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "9"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearUsuario_11()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_10()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "10"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.muerte));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_11()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "11"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_usuario_3());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_12()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "12"));

        // Final
        listaDiálogos.Add(CrearFinal_encuentro()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_13()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "13"));

        // Final
        listaDiálogos.Add(CrearFinal_usuario()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_14()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "14"));

        // Pregunta
        listaDiálogos.Add(HacerPregunta()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearUsuario_15()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "15"));

        // Final
        listaDiálogos.Add(CrearFinal_solitario()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_encuentro()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "ncuentro"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_usuario()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "usuario"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_solitario()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "solitario"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
