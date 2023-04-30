using System.Collections.Generic;
using static Constantes;

// autor_0
// autor_1

public class RutaAutor : InterfazRuta
{
    public ElementoDialogo[] CrearAutor_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "AUTOR 0 (Respuesta)"));

        // Opciones
        listaDiálogos.Add(CrearAutor_1()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearAutor_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "AUTOR 1"));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("Autor_1", TipoFinal.huida));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
