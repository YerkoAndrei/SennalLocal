using UnityEngine;
using TMPro;
using static Constantes;

public class ControladorRadio : MonoBehaviour
{
    private static ControladorRadio instancia;
    private static Rutas rutaAnterior;

    [Header("Referencias")]
    [SerializeField] private TMP_Text txtRuta;

    private void CambiarRuta(Rutas ruta)
    {
        switch(ruta)
        {
            case Rutas.menú:
                txtRuta.text = "MENÚ";
                break;
            case Rutas.intro:
                txtRuta.text = "INTRO";
                break;
            case Rutas.operador:
                txtRuta.text = "OPERADOR";
                break;
            case Rutas.usuario:
                txtRuta.text = "USUARIO";
                break;
            case Rutas.monstruo:
                txtRuta.text = "MONSTRUO";
                break;
            case Rutas.caza:
                txtRuta.text = "CAZA";
                break;
            case Rutas.sótano:
                txtRuta.text = "SÓTANO";
                break;
            case Rutas.autor:
                txtRuta.text = "AUTOR";
                break;
        }
    }

    private void ApagarNombre()
    {
        txtRuta.text = string.Empty;
    }

    public static void CambiarNombreRuta(Rutas ruta)
    {
        if (instancia == null)
            instancia = FindObjectOfType<ControladorRadio>();

        instancia.CambiarRuta(ruta);
    }

    public static void ApagarNombreRuta()
    {
        if (instancia == null)
            instancia = FindObjectOfType<ControladorRadio>();

        instancia.ApagarNombre();
    }

    public static void ReanudarNombreRuta()
    {
        CambiarNombreRuta(rutaAnterior);
    }
}
