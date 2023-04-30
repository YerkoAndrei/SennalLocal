using System.Collections.Generic;
using static Constantes;

// bifurcación_caza_0

// caza_0
// caza_1
// caza_2
// caza_3

public class RutaCaza : InterfazRuta
{
    public ElementoDialogo CrearBifurcación_caza_0()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("Enfréntate a él", CrearCaza_1()[0]));
        listaOpciones.Add(new ElementoOpcion("Acércate despacio", CrearCaza_2()[0]));
        listaOpciones.Add(new ElementoOpcion("Huye", CrearCaza_3()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] CrearCaza_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 0"));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_caza_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearCaza_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 1"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("CAZA_1", TipoFinal.muerte));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearCaza_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 2"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("CAZA_2", TipoFinal.captura));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearCaza_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 3"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("CAZA_3", TipoFinal.captura));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
