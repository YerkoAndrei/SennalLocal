using System.Collections.Generic;
using static Constantes;

// bifurcación_caza_0

// caza_0
// caza_1
// caza_2
// caza_3

public class RutaCaza : InterfazRuta
{
    private Rutas ruta = Rutas.caza;

    public ElementoDialogo CrearBifurcación_caza_0()
    {
        // Preguntas
        var listaOpciones = new List<ElementoOpcion>();
        listaOpciones.Add(new ElementoOpcion("bifurcacion_caza0_0", CrearCaza_1()[0]));
        listaOpciones.Add(new ElementoOpcion("bifurcacion_caza0_1", CrearCaza_2()[0]));
        listaOpciones.Add(new ElementoOpcion("bifurcacion_caza0_2", CrearCaza_3()[0]));

        var diálogoPregunta = ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
        return diálogoPregunta;
    }

    public ElementoDialogo[] CrearCaza_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 0", ruta, NivelEstrés.normal));

        // Opciones
        listaDiálogos.Add(CrearBifurcación_caza_0());
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearCaza_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 1", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("CAZA_1", TipoFinal.muerte, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearCaza_2()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 2", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("CAZA_2", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    private ElementoDialogo[] CrearCaza_3()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "CAZA 3", ruta, NivelEstrés.normal));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("CAZA_3", TipoFinal.captura, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
