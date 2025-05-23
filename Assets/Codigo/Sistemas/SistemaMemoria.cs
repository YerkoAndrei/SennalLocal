﻿// YerkoAndrei
using System;
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
        // Semilla aleatoria
        var fecha = DateTime.Parse("08/02/1996");
        var semilla = (int)(DateTime.Now - fecha).TotalSeconds;

        aleatorio = new System.Random(semilla);
        UnityEngine.Random.InitState(semilla);

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
        if (controladorPizarra == null)
            controladorPizarra = FindObjectOfType<ControladorPizarra>();

        controladorPizarra.ActualizarPizarra();
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
        var bloque = ObtenerBloque(texto);
        return instancia.datos.diálogosElegidos.Contains(bloque);
    }

    public static bool VerificarOpción(string texto)
    {
        return instancia.datos.opcionesElegidas.Contains(texto);
    }

    // Marcado bloque de diálogo visto
    public static void MarcarDiálogo(string texto)
    {
        var bloque = ObtenerBloque(texto);

        if (!instancia.datos.diálogosElegidos.Contains(bloque) &&
            !instancia.datos.opcionesElegidas.Contains(texto) &&
            texto != instancia.datos.últimoNombre)
        {
            instancia.datos.diálogosElegidos.Add(bloque);
            instancia.ActualizarArchivo();
        }
    }

    private static string ObtenerBloque(string texto)
    {
        // Base:        intro0_03
        // Excepción:   operador9_1_0, operador9_2_0
        var bloques = texto.Split("_");
        var bloque = string.Empty;

        if (bloques.Length <= 2)
            return bloques[0];
        else
            return bloques[0] + "_" + bloques[1];
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
        switch (tipoFinal)
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
        switch (respuesta)
        {
            default:
            case RespuestasClave.nada:
                return true;
            case RespuestasClave.encendedorEncontrado:
                return instancia.datos.opcionesElegidas.Contains("opcion_intro0_1");
            case RespuestasClave.peligroExterior:
                return (instancia.datos.opcionesElegidas.Contains("opcion_intro1_0") || instancia.datos.opcionesElegidas.Contains("opcion_operador1_2"));
            case RespuestasClave.llaveComputador:
                return instancia.datos.opcionesElegidas.Contains("opcion_usuario2_2");
            case RespuestasClave.monstruoObservado:
                return instancia.datos.opcionesElegidas.Contains("opcion_monstruo0_1");
            case RespuestasClave.nombreDado:
                return !string.IsNullOrEmpty(instancia.datos.últimoNombre);
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
