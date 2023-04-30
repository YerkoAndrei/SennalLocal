using System.Collections.Generic;
using static Constantes;

// bifurcación_sot_0

// sot_0
// sot_1
// sot_2
// sot_3
// sot_4

public class RutaSotano : InterfazRuta
{
    public ElementoDialogo CrearBifurcación_Sótano_0()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Camina a saltos", CrearSótano_3()[0]));
        listaOpciones.Add(new ElementoOpcion("Ve lento y pisa firme", CrearSótano_4()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] CrearSótano_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 0"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearSótano_2()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearSótano_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 1"));

        // Siguiente diálogo
        listaDiálogos.Add(CrearSótano_2()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearSótano_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 2"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_Sótano_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearSótano_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 3"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("SÓTANO_4", TipoFinal.muerte));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearSótano_4()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "SÓTANO 4"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("SÓTANO_4", TipoFinal.muerte));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
