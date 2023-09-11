using System.Collections.Generic;
using static Constantes;

// autor_0
// autor_1

public class RutaAutor : InterfazRuta
{
    private Rutas ruta = Rutas.autor;

    public ElementoDialogo CrearAutor_0(string pregunta)
    {
        var listaDiálogos = new List<ElementoDialogo>();
        listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "autor0", ruta));

        // Respuesta correspondiente
        switch (pregunta)
        {
            case "pregunta_0":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_0_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_0_1", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_0_2", ruta));
                break;
            case "pregunta_1":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_1_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_1_1", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_1_2", ruta));
                break;
            case "pregunta_2":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_2_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_2_1", ruta));
                break;
            case "pregunta_3":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_3_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_3_1", ruta));
                break;
            case "pregunta_4":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_4_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_4_1", ruta));
                break;
            case "pregunta_5":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_5_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_5_1", ruta));
                break;
            case "pregunta_6":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_6_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_6_1", ruta));
                break;
            case "pregunta_7":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_7_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_7_1", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_7_2", ruta));
                break;
            case "pregunta_8":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_8_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_8_1", ruta));
                break;
            case "pregunta_9":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_9_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_9_1", ruta));
                break;
            case "pregunta_10":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_10_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_10_1", ruta));
                break;
            case "pregunta_11":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_11_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_11_1", ruta));
                break;
            case "pregunta_12":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_12_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_12_1", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_12_2", ruta));
                break;
            case "pregunta_13":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_13_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_13_1", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_13_2", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_13_3", ruta));
                break;
            case "pregunta_14":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_14_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_14_1", ruta));
                break;
            case "pregunta_15":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_15_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_15_1", ruta));
                break;
            case "pregunta_16":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_16_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_16_1", ruta));
                break;
            case "pregunta_17":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_17_0", ruta));
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_17_1", ruta));
                break;
            case "pregunta_18":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_18_0", ruta));
                break;
            case "pregunta_19":
                listaDiálogos.Add(ElementoDialogo.CrearDiálogo(Personajes.operador, "respuesta_19_0", ruta));
                break;
        }

        // Siguiente diálogo
        listaDiálogos.Add(CrearAutor_1());
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearAutor_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_0", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_1", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_2", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_3", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "autor1_4", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "autor1_5", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "autor1_6", ruta, NivelEstrés.alto),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_7", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_8", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_9", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_10", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_11", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_12", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_13", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_14", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.monstruo, "autor1_15", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_16", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_17", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_18", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_19", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_20", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_21", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_22", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "autor1_23", ruta),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_24", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_25", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "autor1_26", ruta, NivelEstrés.bajo),
            ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN AUTOR", ruta, NivelEstrés.bajo, Animaciones.finalAutor),

            // Final
            ElementoDialogo.CrearFinal("AUTOR_1", TipoFinal.escape, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
