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
// ope_9.1
// ope_9.2
// ope_10

public class RutaOperador : InterfazRuta
{
    private Rutas ruta = Rutas.operador;

    private ElementoDialogo CrearBifurcación_operador_0()
    {
        var usuario = new RutaUsuario();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_operador0_0", CrearOperador_3()),
            new ElementoOpcion("opcion_operador0_1", usuario.CrearUsuario_0())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_operador_1()
    {
        var usuario = new RutaUsuario();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_operador1_0", CrearOperador_4()),
            new ElementoOpcion("opcion_operador1_1", CrearOperador_5()),
            new ElementoOpcion("opcion_operador1_2", usuario.CrearUsuario_1())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_operador_2()
    {
        var caza = new RutaCaza();
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_operador2_0", caza.CrearCaza_0()),
            new ElementoOpcion("opcion_operador2_1", CrearOperador_7()),
            new ElementoOpcion("opcion_operador2_2", CrearOperador_6())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo CrearBifurcación_operador_3()
    {
        var listaOpciones = new List<ElementoOpcion>
        {
            new ElementoOpcion("opcion_operador3_0", CrearOperador_8()),
            new ElementoOpcion("opcion_operador3_1", DarNombre())
        };
        return ElementoDialogo.CrearOpciones(listaOpciones.ToArray());
    }

    private ElementoDialogo DarNombre()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            // Pregunta nombre
            ElementoDialogo.CrearPregunta(CrearOperador_9_1(), CrearOperador_9_2(), TipoDiálogo.nombre)
        };
        // Siguiente diálogo Positivo/Negativo
        return listaDiálogos.ToArray()[0];
    }

    public ElementoDialogo CrearOperador_0()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 0", ruta),

            // Siguiente diálogo
            CrearOperador_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    public ElementoDialogo CrearOperador_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 1", ruta),

            // Siguiente diálogo
            CrearOperador_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 2", ruta),

            // Opciones
            CrearBifurcación_operador_0()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_3()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 3", ruta),

            // Opciones
            CrearBifurcación_operador_1()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_4()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 4", ruta),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_4", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_5()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 5", ruta),

            // Opciones
            CrearBifurcación_operador_2()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_6()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 6", ruta),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_6", TipoFinal.muerte, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_7()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 7", ruta),

            // Opciones
            CrearBifurcación_operador_3()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_8()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 8", ruta),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_8", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_9_1()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.operador, "ANIMACIÓN OPERADOR", ruta, NivelEstrés.alto, Animaciones.miraManos),
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 9.1", ruta),

            // Final
            CrearOperador_10()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_9_2()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 9.2", ruta),

            // Final
            CrearOperador_10()
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }

    private ElementoDialogo CrearOperador_10()
    {
        var listaDiálogos = new List<ElementoDialogo>
        {
            ElementoDialogo.CrearDiálogo(Personajes.usuario, "OPERADOR 10", ruta),

            // Final
            ElementoDialogo.CrearFinal("OPERADOR_10", TipoFinal.captura, ruta)
        };
        return AsignarDiálogosYObtenerPrimero(listaDiálogos);
    }
}
