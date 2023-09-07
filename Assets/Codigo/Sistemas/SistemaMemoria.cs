// YerkoAndrei
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using static Constantes;

public class SistemaMemoria : MonoBehaviour
{
    private static SistemaMemoria instancia;

    [SerializeField] private ModeloDatos datos;

    private string rutaArchivo;
    private ControladorPizarra controladorPizarra;

    private void Start()
    {
        if (instancia != null)
            Destroy(gameObject);
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            Iniciar();
        }
    }

    private void Iniciar()
    {
        rutaArchivo = Application.persistentDataPath + "/EstadísticasSeñalLocal";

        if (File.Exists(rutaArchivo))
        {
            // Lee archivo
            var archivo = File.ReadAllText(rutaArchivo);
            var archivoDesencriptado = DesEncriptar(archivo);
            datos = JsonConvert.DeserializeObject<ModeloDatos>(archivoDesencriptado);
        }
        else
            datos = new ModeloDatos();
    }

    private void ActualizarArchivo()
    {
        var datosJson = JsonConvert.SerializeObject(datos);
        var datosEncriptados = DesEncriptar(datosJson);
        File.WriteAllText(rutaArchivo, datosEncriptados);

        // Pizarra
        if(controladorPizarra == null)
            controladorPizarra = FindObjectOfType<ControladorPizarra>();

        controladorPizarra.ActualizarTextos();
    }
    
    // Nombre respondido
    public static void GuardarNombre(string texto)
    {
        instancia.datos.últimoNombre = texto;
        instancia.ActualizarArchivo();
    }

    public static string ObtenerNombreDado()
    {
        return instancia.datos.últimoNombre;
    }

    // Verificar para guardar
    public static bool VerificarDiálogo(string texto)
    {
        return instancia.datos.diálogosElegidos.Contains(texto);
    }

    public static bool VerificarOpción(string texto)
    {
        return instancia.datos.opcionesElegidas.Contains(texto);
    }

    // Marcado visto / elegido
    public static void MarcarDiálogo(string texto)
    {
        if (!instancia.datos.diálogosElegidos.Contains(texto) && texto != instancia.datos.últimoNombre)
        {
            instancia.datos.diálogosElegidos.Add(texto);
            instancia.ActualizarArchivo();
        }
    }

    public static void MarcarOpción(string texto)
    {
        if (!instancia.datos.opcionesElegidas.Contains(texto))
        {
            instancia.datos.opcionesElegidas.Add(texto);
            instancia.ActualizarArchivo();
        }
    }

    public static void MarcarFinal(string texto, TipoFinal tipoFinal)
    {
        switch(tipoFinal)
        {
            case TipoFinal.muerte:
                instancia.datos.usuariosMuertos++;
                break;
            case TipoFinal.captura:
                instancia.datos.usuariosCapturados++;
                break;
            case TipoFinal.escape:
                instancia.datos.usuariosEscapados++;
                break;
        }

        if (!instancia.datos.finalesElegidos.Contains(texto))
            instancia.datos.finalesElegidos.Add(texto);

        instancia.ActualizarArchivo();
    }

    public static void MarcarPregunta(string texto)
    {
        if (!instancia.datos.preguntasEncontradas.Contains(texto))
        {
            instancia.datos.preguntasEncontradas.Add(texto);
            instancia.ActualizarArchivo();
        }
    }

    public static string[] ObtenerPreguntas()
    {
        return instancia.datos.preguntasEncontradas.ToArray();
    }

    public static bool ObtenerRespuestaClave(RespuestasClave respuesta)
    {
        switch(respuesta)
        {
            case RespuestasClave.encendedorEncontrado:
                return instancia.datos.opcionesElegidas.Contains("bifurcacion_intro0_1");
            case RespuestasClave.peligroExterior:
                return (instancia.datos.opcionesElegidas.Contains("bifurcacion_intro1_0") || instancia.datos.opcionesElegidas.Contains("bifurcacion_operador1_2"));
            case RespuestasClave.llaveComputador:
                return instancia.datos.opcionesElegidas.Contains("bifurcacion_usuario2_2");
            case RespuestasClave.monstruoObservado:
                return instancia.datos.opcionesElegidas.Contains("bifurcacion_monstruo0_1");
            case RespuestasClave.nombreDado:
                return !string.IsNullOrEmpty(instancia.datos.últimoNombre);
            default:
                return false;
        }
    }

    // Obtención de variables
    public static int ObtenerUsuariosEscapados()
    {
        return instancia.datos.usuariosEscapados;
    }

    public static int ObtenerUsuariosMuertos()
    {
        return instancia.datos.usuariosMuertos;
    }

    public static int ObtenerUsuariosCapturados()
    {
        return instancia.datos.usuariosCapturados;
    }

    public static int ObtenerDiálogosVistos()
    {
        return instancia.datos.diálogosElegidos.Count;
    }

    public static int ObtenerFinalesAlcanzados()
    {
        return instancia.datos.finalesElegidos.Count;
    }

    public static int ObtenerPreguntasEncontradas()
    {
        return instancia.datos.preguntasEncontradas.Count;
    }
}
