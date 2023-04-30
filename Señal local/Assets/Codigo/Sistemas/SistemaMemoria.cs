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
            datos = JsonConvert.DeserializeObject<ModeloDatos>(archivo);
        }
        else
            datos = new ModeloDatos();
    }

    private void ActualizarArchivo()
    {
        var datosJson = JsonConvert.SerializeObject(datos);
        File.WriteAllText(rutaArchivo, datosJson);
    }

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

    public int ObtenerDiálogosVistos()
    {
        return datos.diálogosElegidos.Count;
    }

    public int ObtenerFinalesAlcanzados()
    {
        return datos.finalesElegidos.Count;
    }

    public bool VerificarDiálogo(string texto)
    {
        return datos.diálogosElegidos.Contains(texto);
    }

    public bool VerificarOpción(string texto)
    {
        return datos.opcionesElegidas.Contains(texto);
    }
}
