using UnityEngine;
using TMPro;
using static Constantes;

public class ControladorRadio : MonoBehaviour
{
    private static ControladorRadio instancia;
    private static Rutas rutaAnterior;

    [Header("Referencias")]
    [SerializeField] private TMP_Text txtRuta;

    private void Awake()
    {
        instancia = this;
    }

    private void CambiarRuta(Rutas ruta)
    {
        switch(ruta)
        {
            case Rutas.menú:
                txtRuta.text = "647F";//MENÚ
                break;
            case Rutas.intro:
                txtRuta.text = "57DB8";//INTRO
                break;
            case Rutas.operador:
                txtRuta.text = "8A4B138B";//OPERADOR
                break;
            case Rutas.usuario:
                txtRuta.text = "ECE1B58";//USUARIO
                break;
            case Rutas.monstruo:
                txtRuta.text = "687CDBE8";//MONSTRUO
                break;
            case Rutas.caza:
                txtRuta.text = "21G1";//CAZA
                break;
            case Rutas.sótano:
                txtRuta.text = "C9D178";//SÓTANO
                break;
            case Rutas.autor:
                txtRuta.text = "1ED8B";//AUTOR
                break;
        }
    }

    private void ApagarNombre()
    {
        txtRuta.text = string.Empty;
    }

    public static void CambiarNombreRuta(Rutas ruta)
    {
        instancia.CambiarRuta(ruta);
    }

    public static void ApagarNombreRuta()
    {
        instancia.ApagarNombre();
    }

    public static void ReanudarNombreRuta()
    {
        CambiarNombreRuta(rutaAnterior);
    }
}

// Abecedario español
//01 - a
//02 - á
//03 - b
//04 - c
//05 - d
//06 - e
//07 - é
//08 - f
//09 - g
//10 - h
//11 - i
//12 - í
//13 - j
//14 - k
//15 - l
//16 - m
//17 - n
//18 - ñ
//19 - o
//20 - ó
//21 - p
//22 - q
//23 - r
//24 - s
//25 - t
//26 - u
//27 - ú
//28 - ü
//29 - v
//30 - w
//31 - x
//32 - y
//33 - z

// Rutas
//1 - a
//2 - c
//3 - d
//4 - e
//5 - i
//6 - m
//7 - n
//8 - o
//9 - ó
//A - p
//B - r
//C - s
//D - t
//E - u
//F - ú
//G - z 
