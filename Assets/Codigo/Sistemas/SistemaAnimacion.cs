﻿// YerkoAndrei
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Constantes;

public class SistemaAnimacion : MonoBehaviour
{
    private static SistemaAnimacion instancia;
    public static Gráficos gráficos;

    [Header("Personajes")]
    [SerializeField] private GameObject usuario;

    [Header("Animadores")]
    [SerializeField] private Animator animadorOperador;
    [SerializeField] private Animator animadorUsuario;
    [SerializeField] private Animator animadorSilla;
    [SerializeField] private Animator animadorPuerta;

    [Header("Curvas")]
    [SerializeField] private AnimationCurve curvaAnimaciónEstandar;

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
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            MostrarAnimación(Animaciones.Escribir);

        if (Input.GetKeyDown(KeyCode.I))
            MostrarAnimación(Animaciones.Sentarse);

        if (Input.GetKeyDown(KeyCode.O))
            MostrarAnimación(Animaciones.Pararse);

        if (Input.GetKeyDown(KeyCode.P))
            MostrarAnimación(Animaciones.Entrar);
    }
    
    private void Iniciar()
    {
        // Recuerda anterior o usa predeterminado
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("gráficos")))
            CambiarGráficos(Gráficos.altos);
        else
            CambiarGráficos((Gráficos)Enum.Parse(typeof(Gráficos), PlayerPrefs.GetString("gráficos")));
    }

    public static void CambiarGráficos(Gráficos nuevosGráficos)
    {
        gráficos = nuevosGráficos;
        PlayerPrefs.SetString("gráficos", gráficos.ToString());

        QualitySettings.SetQualityLevel((int)gráficos, true);
    }

    // Animaciones juego
    public static void MostrarAnimación(Animaciones animación)
    {
        switch(animación)
        {
            case Animaciones.Escribir:
                instancia.AnimarEscribir();
                break;
            case Animaciones.Sentarse:
                instancia.AnimarSentarse();
                break;
            case Animaciones.Pararse:
                instancia.AnimarPararse();
                break;
            case Animaciones.Entrar:
                instancia.AnimarEntrar();
                break;
        }
    }

    public void AnimarEscribir()
    {
        animadorOperador.SetTrigger("Escribir");
    }

    public void AnimarSentarse()
    {
        animadorOperador.SetTrigger("Sentarse");
        animadorSilla.SetTrigger("Entrar");
        SistemaSonidos.ReproducirAnimación(Animaciones.Sentarse);
    }

    public void AnimarPararse()
    {
        animadorOperador.SetTrigger("Pararse");
        animadorSilla.SetTrigger("Salir");
        SistemaSonidos.ReproducirAnimación(Animaciones.Pararse);
    }

    public void AnimarEntrar()
    {
        usuario.SetActive(true);
        animadorUsuario.SetTrigger("Entrar");
        animadorPuerta.SetTrigger("Abrir");
        SistemaSonidos.ReproducirAnimación(Animaciones.Entrar);
    }

    // Animaciones interfaz
    public static float EvaluarCurva(float tiempo)
    {
        return instancia.curvaAnimaciónEstandar.Evaluate(tiempo);
    }

    public static void AnimarPanel(RectTransform elemento, float duraciónLerp, bool entrando, bool conCurva, Direcciones dirección, Action alFinal)
    {
        instancia.StartCoroutine(AnimaciónMovimiento(elemento, duraciónLerp, entrando, conCurva, dirección, alFinal));
    }

    public static void AnimarColor(Image elemento, float duraciónLerp, Color colorInicio, Color colorFinal, Action alFinal)
    {
        instancia.StartCoroutine(AnimaciónColor(elemento, duraciónLerp, colorInicio, colorFinal, alFinal));
    }

    // Intercalación lineal sin curva
    private static IEnumerator AnimaciónMovimiento(RectTransform elemento, float duraciónLerp, bool entrando, bool conCurva, Direcciones dirección, Action alFinal)
    {
        var posiciónFuera = Vector2.zero;

        switch(dirección)
        {
            case Direcciones.arriba:
                posiciónFuera = new Vector2(0, 1000);
                break;
            case Direcciones.abajo:
                posiciónFuera = new Vector2(0, -1000);
                break;
            case Direcciones.izquierda:
                posiciónFuera = new Vector2(-2000, 0);
                break;
            case Direcciones.derecha:
                posiciónFuera = new Vector2(2000, 0);
                break;
        }

        if (entrando)
            elemento.anchoredPosition = posiciónFuera;
        else
            elemento.anchoredPosition = Vector2.zero;

        float tiempoLerp = 0;
        float tiempo = 0;
        while (tiempoLerp < duraciónLerp)
        {
            if (conCurva)
                tiempo = EvaluarCurva(tiempoLerp / duraciónLerp);
            else
                tiempo = tiempoLerp / duraciónLerp;

            if (entrando)
                elemento.anchoredPosition = Vector2.Lerp(posiciónFuera, Vector2.zero, tiempo);
            else
                elemento.anchoredPosition = Vector2.Lerp(Vector2.zero, posiciónFuera, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        if (entrando)
            elemento.anchoredPosition = Vector2.zero;
        else
            elemento.anchoredPosition = posiciónFuera;

        if (alFinal != null)
            alFinal.Invoke();
    }

    private static IEnumerator AnimaciónColor(Image elemento, float duraciónLerp, Color colorInicio, Color colorFinal, Action alFinal)
    {
        elemento.color = colorInicio;

        float tiempoLerp = 0;
        while (tiempoLerp < duraciónLerp)
        {
            var tiempo = EvaluarCurva(tiempoLerp / duraciónLerp);
            elemento.color = Color.Lerp(colorInicio, colorFinal, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        elemento.color = colorFinal;

        if (alFinal != null)
            alFinal.Invoke();
    }
}
