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

public class RutaMonstruo : InterfazRuta
{
    public ElementoDialogo CrearBifurcación_monstruo_0()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Ignoralo", usuario.CrearUsuario_5()[0]));
        listaOpciones.Add(new ElementoOpcion("Míralo", CrearMonstruo_2()[0]));
        listaOpciones.Add(new ElementoOpcion("Síguelo", CrearMonstruo_3()[0]));
        listaOpciones.Add(new ElementoOpcion("Atácalo", CrearMonstruo_4()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_1()
    {
        var usuario = new RutaUsuario();
        var sótano = new RutaSotano();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Pídele ayuda", usuario.CrearUsuario_6()[0]));
        listaOpciones.Add(new ElementoOpcion("Ayúdale", CrearMonstruo_5()[0]));
        listaOpciones.Add(new ElementoOpcion("Fuerza la puerta", sótano.CrearSótano_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_2()
    {
        var sótano = new RutaSotano();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Vete", CrearMonstruo_6()[0]));
        listaOpciones.Add(new ElementoOpcion("Síguelo", CrearMonstruo_7()[0]));
        listaOpciones.Add(new ElementoOpcion("Abre la puerta", sótano.CrearSótano_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_3()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Pregunta quién eres", CrearMonstruo_8()[0]));
        listaOpciones.Add(new ElementoOpcion("Pregunta quién es", DarNombreMonstruo()[0]));
        listaOpciones.Add(new ElementoOpcion("PREGUNTA...", CrearFinal_autor()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] DarNombreMonstruo()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "preparación"));

        // Pregunta
        listaDiálogos.Add(ElementoDialogo.CrearPregunta(Personajes.operador, "pregunta"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearMonstruo_9()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_0()
    {
        var usuario = new RutaUsuario();
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "0"));

        // Opciones
        listaDiálogos.Add(usuario.CrearBifurcación_usuario_0());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "1"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_0());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "2"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_1());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "3"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_1());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "4"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "5"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_2());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_6()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "6"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_7()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "7"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_3());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_8()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "8"));

        // Final
        listaDiálogos.Add(CrearFinal_anterior()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_9()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "9"));

        // Final
        listaDiálogos.Add(CrearFinal_monstruo()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_anterior()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "anterior"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_monstruo()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "monstruo"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_autor()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor"));

        // Final
        //listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
