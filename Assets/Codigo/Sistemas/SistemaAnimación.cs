﻿// YerkoAndrei
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Constantes;

public class SistemaAnimación : MonoBehaviour
{
    private static SistemaAnimación instancia;

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

    private void Iniciar()
    {

    }

    public static float EvaluarCurva(float tiempo)
    {
        return instancia.curvaAnimaciónEstandar.Evaluate(tiempo);
    }

    public static void AnimarPanel(RectTransform elemento, float duraciónLerp, bool entrando, Direcciones dirección, Action alFinal)
    {
        instancia.StartCoroutine(AnimaciónMovimiento(elemento, duraciónLerp, entrando, dirección, alFinal));
    }

    public static void AnimarColor(Image elemento, float duraciónLerp, Color colorInicio, Color colorFinal, Action alFinal)
    {
        instancia.StartCoroutine(AnimaciónColor(elemento, duraciónLerp, colorInicio, colorFinal, alFinal));
    }

    // Intercalación lineal sin curva
    private static IEnumerator AnimaciónMovimiento(RectTransform elemento, float duraciónLerp, bool entrando, Direcciones dirección, Action alFinal)
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
        while (tiempoLerp < duraciónLerp)
        {
            var tiempo = tiempoLerp / duraciónLerp;

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
