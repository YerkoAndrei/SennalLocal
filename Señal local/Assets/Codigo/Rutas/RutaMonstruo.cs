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
    public ElementoDialogo CrearBifurcación_monstruo_0()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Ignoralo", usuario.CrearUsuario_7()[0]));
        listaOpciones.Add(new ElementoOpcion("Míralo bien", CrearMonstruo_2()[0]));
        listaOpciones.Add(new ElementoOpcion("Síguelo", CrearMonstruo_3()[0]));
        listaOpciones.Add(new ElementoOpcion("Atácalo", CrearMonstruo_4()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_1()
    {
        var usuario = new RutaUsuario();
        var sótano = new RutaSotano();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Pídele ayuda", usuario.CrearUsuario_8()[0]));
        listaOpciones.Add(new ElementoOpcion("Ayúdale", CrearMonstruo_6()[0]));
        listaOpciones.Add(new ElementoOpcion("Fuerza la puerta", sótano.CrearSótano_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_2()
    {
        var sótano = new RutaSotano();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Vete", CrearMonstruo_7()[0]));
        listaOpciones.Add(new ElementoOpcion("Acércate", CrearMonstruo_8()[0]));
        listaOpciones.Add(new ElementoOpcion("Abre la puerta", sótano.CrearSótano_1()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_monstruo_3()
    {
        var autor = new RutaAutor();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Pregúntale quién eres", CrearMonstruo_9()[0]));
        listaOpciones.Add(new ElementoOpcion("Pregúntale quién es", ResponderNombre()[0]));
        listaOpciones.Add(new ElementoOpcion("Pregunta..", autor.CrearAutor_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] ResponderNombre()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "preparación"));

        // Pregunta
        listaDiálogos.Add(ElementoDialogo.CrearPregunta());

        // Siguiente diálogo
        listaDiálogos.Add(CrearMonstruo_10()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_0()
    {
        var usuario = new RutaUsuario();
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 0"));

        // Opciones
        listaDiálogos.Add(usuario.CrearBifurcación_usuario_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 1"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 2"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearMonstruo_5()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 3"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearMonstruo_5()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 4"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(TipoFinal.captura));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 5"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_1());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_6()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 6"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_2());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_7()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 7"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(TipoFinal.captura));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_8()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 8"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_monstruo_3());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_9()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 9"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(TipoFinal.captura));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearMonstruo_10()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "MONSTRUO 9"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(TipoFinal.captura));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
