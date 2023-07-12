using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using static Constantes;

public class SistemaMemoria : MonoBehaviour
{
    private static SistemaMemoria instancia;

    [SerializeField] private ModeloDatos datos;

    private string rutaArchivo;

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
    }
    
    // Nombre respondido
    public static void GuardarNombre(string texto)
    {
        instancia.datos.últimoNombre = texto;
        instancia.ActualizarArchivo();
    }

    public string CargarNombre()
    {
        return datos.últimoNombre;
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
        if (!instancia.datos.diálogosElegidos.Contains(texto))
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
            case TipoFinal.huida:
                instancia.datos.usuariosHuidos++;
                break;
            case TipoFinal.muerte:
                instancia.datos.usuariosMuertos++;
                break;
            case TipoFinal.captura:
                instancia.datos.usuariosCapturados++;
                break;
        }

        if (!instancia.datos.finalesElegidos.Contains(texto))
        {
            instancia.datos.finalesElegidos.Add(texto);
            instancia.ActualizarArchivo();
        }
    }

    public static void MarcarPregunta(string texto)
    {
        if (!instancia.datos.preguntasEncontradas.Contains(texto))
        {
            instancia.datos.preguntasEncontradas.Add(texto);
            instancia.ActualizarArchivo();
        }
    }

    // Obtención de variables
    public static int ObtenerUsuariosHuidos()
    {
        return instancia.datos.usuariosHuidos;
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
