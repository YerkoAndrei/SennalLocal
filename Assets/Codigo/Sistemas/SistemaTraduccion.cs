﻿// YerkoAndrei
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Constantes;

public class SistemaTraduccion : MonoBehaviour
{
    private static SistemaTraduccion instancia;
    public static Idiomas idioma;

    [Header("Menu")]
    [SerializeField] private TextAsset menu_español;
    [SerializeField] private TextAsset menu_inglés;

    [Header("Guión")]
    [SerializeField] private TextAsset guión_español;
    [SerializeField] private TextAsset guión_inglés;

    private static Dictionary<string, string> diccionario;

    private void Start()
    {
        if (instancia != null)
            Destroy(gameObject);
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.activeSceneChanged += EnCambioEscena;
            Iniciar();
        }
    }

    private void Iniciar()
    {
        // Recuerda anterior o usa idioma de sistema
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("idioma")))
        {
            // Revisa el idioma instalado. ISO 639-1
            var lenguajeSistema = System.Globalization.CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
            switch (lenguajeSistema)
            {
                default:
                case "es":
                    CambiarIdioma(Idiomas.español);
                    break;
                case "en":
                    CambiarIdioma(Idiomas.inglés);
                    break;
            }
        }
        else
            CambiarIdioma((Idiomas)Enum.Parse(typeof(Idiomas), PlayerPrefs.GetString("idioma")));
    }

    private void EnCambioEscena(Scene current, Scene next)
    {
        ActualizarTextosEscena();
    }

    public static void CambiarIdioma(Idiomas nuevoIdioma)
    {
        idioma = nuevoIdioma;
        PlayerPrefs.SetString("idioma", idioma.ToString());

        switch (nuevoIdioma)
        {
            default:
            case Idiomas.español:
                diccionario = UnirTextosJSON(new string[] { instancia.menu_español.text, instancia.guión_español.text });
                break;
            case Idiomas.inglés:
                diccionario = UnirTextosJSON(new string[] { instancia.menu_inglés.text, instancia.guión_inglés.text });
                break;
        }
        instancia.ActualizarTextosEscena();
    }

    private void ActualizarTextosEscena()
    {
        // Encuentra incluso desactivados
        var elementosTraducibles = Resources.FindObjectsOfTypeAll<ElementoTraducible>();
        for (int i = 0; i < elementosTraducibles.Length; i++)
        {
            elementosTraducibles[i].MostrarTexto();
        }
    }

    private static Dictionary<string, string> UnirTextosJSON(string[] traducciones)
    {
        var textoFinal = string.Empty;

        // Unión de JSONs de idioma en un solo diccionario
        for (int i = 0; i < traducciones.Length; i++)
        {
            var texto = traducciones[i].Replace("{", "").Replace("}", "");
            if (i < (traducciones.Length - 1))
                texto += ",";

            textoFinal += texto;
        }

        textoFinal = "{" + textoFinal + "}";
        var diccionario = JsonConvert.DeserializeObject<Dictionary<string, string>>(textoFinal);
        return diccionario;
    }

    public static string ObtenerTraducción(string código)
    {
        if (diccionario.ContainsKey(código))
            return diccionario[código];
        else
        {
            Debug.LogError("Código traducible no encontrado: " + código);
            return string.Empty;
        }
    }
}
