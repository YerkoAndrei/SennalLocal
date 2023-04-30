using System.Collections.Generic;
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
    public ElementoDialogo CrearBifurcación_operador_0()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Sal de la casa", CrearOperador_3()[0]));
        listaOpciones.Add(new ElementoOpcion("Adéntrate en la casa", usuario.CrearUsuario_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_1()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Ve lento", CrearOperador_4()[0]));
        listaOpciones.Add(new ElementoOpcion("Corre rápido", CrearOperador_5()[0]));
        listaOpciones.Add(new ElementoOpcion("Devuélvete", usuario.CrearUsuario_1()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_2()
    {
        var caza = new RutaCaza();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Ve al edificio verde", caza.CrearCaza_0()[0]));
        listaOpciones.Add(new ElementoOpcion("Ve al edificio rojo", CrearOperador_7()[0]));
        listaOpciones.Add(new ElementoOpcion("Ve al edificio azul", CrearOperador_6()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_3()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Es irrelevante", CrearOperador_8()[0]));
        listaOpciones.Add(new ElementoOpcion("Me llamo...", DarNombre()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] DarNombre()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Pregunta
        listaDiálogos.Add(ElementoDialogo.CrearPregunta());

        // Siguiente diálogo
        listaDiálogos.Add(CrearOperador_9()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 0"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearOperador_2()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 1"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearOperador_2()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 2"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 3"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_1());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 4"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("OPERADOR_4", TipoFinal.muerte));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 5"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_2());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_6()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 6"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("OPERADOR_6", TipoFinal.muerte));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_7()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 7"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_3());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_8()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 8"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("OPERADOR_8", TipoFinal.captura));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_9()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 9"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("OPERADOR_9", TipoFinal.captura));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
