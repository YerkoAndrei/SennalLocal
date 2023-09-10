using System.Collections.Generic;
using static Constantes;

// autor_0
// autor_1

public class RutaAutor : InterfazRuta
{
    private Rutas ruta = Rutas.autor;

    public ElementoDialogo CrearAutor_0()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            // Respuesta a pregunta encontrada
            ElementoDialogo.CrearDiálogo(Personajes.operador, "RESPUESTA 0", ruta),

            // Siguiente diálogo
            CrearAutor_1()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearAutor_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.operador, "AUTOR 1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN AUTOR", ruta, NivelEstrés.muerto, Animaciones.finalAutor),

            // Final
            ElementoDialogo.CrearFinal("Autor_1", TipoFinal.escape, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
