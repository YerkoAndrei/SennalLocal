using System.Collections.Generic;
using static Constantes;

// autor_0
// autor_1

public class RutaAutor : InterfazRuta
{
    private Rutas ruta = Rutas.autor;

    public ElementoDialogo[] CrearAutor_0()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "AUTOR 0 (Respuesta)", ruta, NivelEstrés.normal));

        // Opciones
        listaDiálogos.Add(CrearAutor_1()[0]);
        return AsignarContinuidadDiálogos(listaDiálogos);
    }

    public ElementoDialogo[] CrearAutor_1()
    {
        var listaDiálogos = new List<ElementoDialogo>();

        // Diálogos
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.usuario, "AUTOR 1", ruta, NivelEstrés.normal));
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN AUTOR", ruta, NivelEstrés.normal, Animaciones.finalAutor));

        // Final
        listaDiálogos.Add(ElementoDialogo.CrearFinal("Autor_1", TipoFinal.escape, ruta));
        return AsignarContinuidadDiálogos(listaDiálogos);
    }
}
