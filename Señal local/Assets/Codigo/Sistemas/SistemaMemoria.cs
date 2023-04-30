using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using static Constantes;

public class SistemaMemoria : MonoBehaviour
{
    public static SistemaMemoria instancia;

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
    public void GuardarNombre(string texto)
    {
        datos.últimoNombre = texto;
        ActualizarArchivo();
    }

    public string CargarNombre()
    {
        return datos.últimoNombre;
    }

    // Verificar para guardar
    public bool VerificarDiálogo(string texto)
    {
        return datos.diálogosElegidos.Contains(texto);
    }

    public bool VerificarOpción(string texto)
    {
        return datos.opcionesElegidas.Contains(texto);
    }

    // Marcado visto / elegido
    public void MarcarDiálogo(string texto)
    {
        if (!datos.diálogosElegidos.Contains(texto))
        {
            datos.diálogosElegidos.Add(texto);
            ActualizarArchivo();
        }
    }

    public void MarcarOpción(string texto)
    {
        if (!datos.opcionesElegidas.Contains(texto))
        {
            datos.opcionesElegidas.Add(texto);
            ActualizarArchivo();
        }
    }

    public void MarcarFinal(string texto, TipoFinal tipoFinal)
    {
        switch(tipoFinal)
        {
            case TipoFinal.huida:
                datos.usuariosHuidos++;
                break;
            case TipoFinal.muerte:
                datos.usuariosMuertos++;
                break;
            case TipoFinal.captura:
                datos.usuariosCapturados++;
                break;
        }

        if (!datos.finalesElegidos.Contains(texto))
        {
            datos.finalesElegidos.Add(texto);
            ActualizarArchivo();
        }
    }

    public void MarcarPregunta(string texto)
    {
        if (!datos.preguntasEncontradas.Contains(texto))
        {
            datos.preguntasEncontradas.Add(texto);
            ActualizarArchivo();
        }
    }

    // Obtención de variables
    public int ObtenerUsuariosHuidos()
    {
        return datos.usuariosHuidos;
    }

    public int ObtenerUsuariosMuertos()
    {
        return datos.usuariosMuertos;
    }

    public int ObtenerUsuariosCapturados()
    {
        return datos.usuariosCapturados;
    }

    public int ObtenerDiálogosVistos()
    {
        return datos.diálogosElegidos.Count;
    }

    public int ObtenerFinalesAlcanzados()
    {
        return datos.finalesElegidos.Count;
    }

    public int ObtenerPreguntasEncontradas()
    {
        return datos.preguntasEncontradas.Count;
    }
}
