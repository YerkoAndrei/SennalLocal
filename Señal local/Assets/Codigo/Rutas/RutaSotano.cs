using System.Collections.Generic;
using static Constantes;

// bifurcación_sot_0

// sot_0
// sot_1
// sot_2

public class RutaSotano : InterfazRuta
{
    public ElementoDialogo CrearBifurcación_Sótano_0()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Camina a saltos", CrearSótano_1()[0]));
        listaOpciones.Add(new ElementoOpcion("Ve lento. Pisa firme", CrearSótano_2()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(Personajes.usuario, "¿Qué hago?", listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] CrearSótano_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "0"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_Sótano_0());

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearSótano_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "1"));

        // Final
        listaDiálogos.Add(CrearFinal_sotano()[0]);

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearSótano_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "2"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.muerte));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearFinal_sotano()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "sotano"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal(Personajes.usuario, "final", TipoFinal.captura));

        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
