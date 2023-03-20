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

public class RutaOperador : InterfazRuta
{
    public ElementoDialogo CrearBifurcación_operador_0()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Intenta salir de la casa", CrearOperador_2()[0]));
        listaOpciones.Add(new ElementoOpcion("Sigue buscando dentro de la casa", usuario.CrearUsuario_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_1()
    {
        var usuario = new RutaUsuario();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Ve lento", CrearOperador_3()[0]));
        listaOpciones.Add(new ElementoOpcion("Corre rápido", CrearOperador_4()[0]));
        listaOpciones.Add(new ElementoOpcion("Devuélvete", usuario.CrearUsuario_0()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_2()
    {
        var caza = new RutaCaza();

        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Ve al edificio verde", caza.CrearCaza_0()[0]));
        listaOpciones.Add(new ElementoOpcion("Ve al edificio rojo", CrearOperador_6()[0]));
        listaOpciones.Add(new ElementoOpcion("Ve al edificio azul", CrearOperador_5()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo CrearBifurcación_operador_3()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Es irrelevante", CrearOperador_7()[0]));
        listaOpciones.Add(new ElementoOpcion("Me llamo...", DarNombre()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] DarNombre()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "preparación"));

        // Pregunta
        listaDiálogos.Add(ElementoDialogo.CrearPregunta(Personajes.operador, "pregunta"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearOperador_8()[0]);

        return listaDiálogos.ToArray();
    }

    public ElementoDialogo[] CrearOperador_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "0"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_0());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "1"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_0());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "2"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_1());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "3"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.muerte));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "4"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_2());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_5()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "5"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.muerte));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_6()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "6"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_operador_3());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_7()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "7"));

        // Final
        listaDiálogos.Add(CrearFinal_secuestros()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearOperador_8()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "8"));

        // Final
        listaDiálogos.Add(CrearFinal_operador()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_secuestros()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "secuestros"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_operador()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "operador"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
