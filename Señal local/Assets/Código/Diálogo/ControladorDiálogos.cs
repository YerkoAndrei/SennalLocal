// YerkoAndrei
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;

public class ControladorDiálogos : MonoBehaviour
{
    public enum Estados
    {
        pausa,
        esperandoClic,
        mostrandoDiálogo,
        mostrandoOpciones,
        animación
    }

    public enum Personajes
    {
        usuario,
        operador,
        monstruo,
        sobreviviente,
        computador
    }

    public enum TipoDiálogo
    {
        diálogo,
        opciones,
        pregunta,
        final
    }

    public enum TipoFinal
    {
        muerte,
        captura
    }

    [Header("Estado")]
    [Ocultar] [SerializeField] private Estados estado;
    [Ocultar] [SerializeField] private ElementoDiálogo diálogoActual;

    [Header("Diálogo Inicial")]
    [SerializeField] private ElementoDiálogo diálogoInicial;

    [Header("Tiempos")]
    [SerializeField] private float tiempoOpciones;
    [SerializeField] private float tiempoLetra;
    [SerializeField] private float tiempoLetraEtiquetada;
    [SerializeField] private float tiempoEspacio;
    [SerializeField] private float tiempoComa;
    [SerializeField] private float tiempoPunto;

    [Header("Colores")]
    [SerializeField] private Color colorCargando;
    [SerializeField] private Color colorContinuar;

    [Header("Referencias diálogos")]
    [SerializeField] private TMP_Text txtDiálogo;
    [SerializeField] private Image imgPersonaje;
    [SerializeField] private Image imgContinuar;

    [Header("Referencias opciones")]
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private Transform padreOpciones;
    [SerializeField] private GameObject btnOpciónPrefab;

    [Header("Referencias audios")]
    [SerializeField] private AudioSource fuenteMúsica;
    [SerializeField] private AudioSource fuenteDiálogo;

    [Header("Personajes")]
    [SerializeField] private Sprite imagenUsuario;
    [SerializeField] private Sprite imagenOperador;
    [SerializeField] private Sprite imagenMonstruo;
    [SerializeField] private Sprite imagenSobreviviente;
    [SerializeField] private Sprite imagenComputador;

    [Header("Fuentes")]
    [SerializeField] private TMP_FontAsset fuenteUsuario;
    [SerializeField] private TMP_FontAsset fuenteOperador;
    [SerializeField] private TMP_FontAsset fuenteMonstruo;
    [SerializeField] private TMP_FontAsset fuenteSobreviviente;
    [SerializeField] private TMP_FontAsset fuenteComputador;

    [Header("Audios")]
    [SerializeField] private AudioClip audioUsuario;
    [SerializeField] private AudioClip audioOperador;
    [SerializeField] private AudioClip audioMonstruo;
    [SerializeField] private AudioClip audioSobreviviente;
    [SerializeField] private AudioClip audioComputador;

    private List<ElementoInterfazOpción> opcionesActuales;
    private bool mostrandoTexto;
    private bool puedeContinuar;
    private bool carácterDeEtiqueta;
    private bool carácterEnTextoRico;
    private float contadorTiempo;
    private float tiempoDiálogo;

    private const char carácterEtiqueta = '#';

    private void Start()
    {
        panelOpciones.SetActive(false);
        VerImagenContinuar(false);

        opcionesActuales = new List<ElementoInterfazOpción>();
        txtDiálogo.text = string.Empty;

        foreach (Transform hijo in padreOpciones)
        {
            Destroy(hijo.gameObject);
        }

        IniciarDiálogo(diálogoInicial);
    }

    private void Update()
    {
        // Llenado imagen continuar
        if (!puedeContinuar)
        {
            contadorTiempo += Time.deltaTime;
            imgContinuar.fillAmount = contadorTiempo / tiempoDiálogo;
        }

        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
            EnClic();
    }

    public void EnClic()
    {
        switch (estado)
        {
            case Estados.mostrandoDiálogo:
                ApurarDiálogo();
                break;
            case Estados.esperandoClic:
                ContinuarSiguienteAcción();
                break;
        }
    }

    private void IniciarDiálogo(ElementoDiálogo _diálogoActual)
    {
        estado = Estados.mostrandoDiálogo;
        diálogoActual = _diálogoActual;
        ContarTiempoDiálogo();

        StartCoroutine(MostrarTexto());
    }

    private void ApurarDiálogo()
    {
        if (mostrandoTexto && txtDiálogo.text.Length > 1 && !puedeContinuar)
            TerminarTexto();
    }

    private void ContarTiempoDiálogo()
    {
        // Cuánto tiempo se demorará (texto rico se reemplaza por carácterEtiqueta)
        tiempoDiálogo = 0;
        var textoLimpio = ReemplazarEtiquetas(diálogoActual.texto);

        for (int i = 0; i < textoLimpio.Length; i++)
        {
            switch (textoLimpio[i])
            {
                default:
                    tiempoDiálogo += tiempoLetra;
                    break;
                case carácterEtiqueta:
                    tiempoDiálogo += tiempoLetraEtiquetada;
                    break;
                case ' ':
                    tiempoDiálogo += tiempoEspacio;
                    break;
                case ',':
                    tiempoDiálogo += tiempoComa;
                    break;
                case '.':
                    tiempoDiálogo += tiempoPunto;
                    break;
            }
        }
    }

    public string ReemplazarEtiquetas(string texto)
    {
        // Aisla etiquetas
        var encontrado = Regex.Matches(texto, "<.*?>.*?<.*?>");
        var textoEncontrado = Regex.Replace(texto, "<.*?>", string.Empty);

        // Reemplaza texto dentro de etiquetas por carácter especial
        for (int i = 0; i < encontrado.Count; i++)
        {
            var ayy = Regex.Replace(encontrado[i].ToString(), "<.*?>", string.Empty);

            for (int e = 0; e < ayy.Length; e++)
            {
                textoEncontrado += carácterEtiqueta;
            }
        }

        return textoEncontrado;
    }

    private IEnumerator MostrarTexto()
    {
        txtDiálogo.text = string.Empty;
        mostrandoTexto = true;
        puedeContinuar = false;
        VerImagenContinuar(false);

        // Cambio de fuentes
        switch (diálogoActual.personaje)
        {
            case Personajes.usuario:
                txtDiálogo.font = fuenteUsuario;
                imgPersonaje.sprite = imagenUsuario;
                break;
            case Personajes.operador:
                txtDiálogo.font = fuenteOperador;
                imgPersonaje.sprite = imagenOperador;
                break;
            case Personajes.monstruo:
                txtDiálogo.font = fuenteMonstruo;
                imgPersonaje.sprite = imagenMonstruo;
                break;
            case Personajes.sobreviviente:
                txtDiálogo.font = fuenteSobreviviente;
                imgPersonaje.sprite = imagenSobreviviente;
                break;
            case Personajes.computador:
                txtDiálogo.font = fuenteComputador;
                imgPersonaje.sprite = imagenComputador;
                break;                
        }

        // Maneja texto rico
        var texto = diálogoActual.texto;
        carácterDeEtiqueta = false;
        carácterEnTextoRico = false;

        for (int i = 0; i < texto.Length; i++)
        {
            if (mostrandoTexto)
            {
                // Omite tiempos en etiquetas
                if (texto[i] == '<' || carácterDeEtiqueta)
                {
                    carácterDeEtiqueta = true;
                    txtDiálogo.text += texto[i];

                    if (texto[i] == '>')
                    {
                        carácterDeEtiqueta = false;
                        carácterEnTextoRico = !carácterEnTextoRico;
                    }
                }
                else
                {
                    txtDiálogo.text += texto[i];

                    // Si el carácter está dentro de una etiqueta
                    if (carácterEnTextoRico)
                    {
                        ActivarSonidoPersonaje();
                        yield return new WaitForSeconds(tiempoLetraEtiquetada);
                        continue;
                    }

                    // Pausa según carácter
                    switch (texto[i])
                    {
                        default:
                            ActivarSonidoPersonaje();
                            yield return new WaitForSeconds(tiempoLetra);
                            break;
                        case ' ':
                            yield return new WaitForSeconds(tiempoEspacio);
                            break;
                        case ',':
                            yield return new WaitForSeconds(tiempoComa);
                            break;
                        case '.':
                            yield return new WaitForSeconds(tiempoPunto);
                            break;
                    }
                }
            }
            else
                break;
        }
        TerminarTexto();
    }

    private void TerminarTexto()
    {
        puedeContinuar = true;
        mostrandoTexto = false;
        txtDiálogo.text = diálogoActual.texto;
        VerImagenContinuar(true);

        estado = Estados.esperandoClic;
    }

    private void ActivarSonidoPersonaje()
    {
        switch (diálogoActual.personaje)
        {
            case Personajes.usuario:
                fuenteDiálogo.PlayOneShot(audioUsuario);
                break;
            case Personajes.operador:
                fuenteDiálogo.PlayOneShot(audioOperador);
                break;
            case Personajes.monstruo:
                fuenteDiálogo.PlayOneShot(audioMonstruo);
                break;
            case Personajes.sobreviviente:
                fuenteDiálogo.PlayOneShot(audioSobreviviente);
                break;
            case Personajes.computador:
                fuenteDiálogo.PlayOneShot(audioComputador);
                break;
        }
    }

    private void ContinuarSiguienteAcción()
    {
        switch (diálogoActual.tipoDiálogo)
        {
            case TipoDiálogo.diálogo:
                IniciarDiálogo(diálogoActual.siguienteDiálogo);
                break;
            case TipoDiálogo.opciones:
                IniciarOpciones();
                break;
            case TipoDiálogo.final:
                FinalizarPartida(diálogoActual.tipoFinal);
                break;
        }
    }

    private void VerImagenContinuar(bool activo)
    {
        if (activo)
        {
            imgContinuar.fillAmount = 1;
            imgContinuar.color = colorContinuar;
        }
        else
        {
            contadorTiempo = 0;
            imgContinuar.fillAmount = contadorTiempo;
            imgContinuar.color = colorCargando;
        }
    }

    private void IniciarOpciones()
    {
        estado = Estados.mostrandoOpciones;
        panelOpciones.SetActive(true);

        // Borra anteriores
        foreach (Transform hijo in padreOpciones)
        {
            Destroy(hijo.gameObject);
        }

        // Posición aleatoria
        var aleatoria = new Random(ControladorMenú.semilla);
        var opciones = diálogoActual.opciones.OrderBy(x => aleatoria.Next()).ToArray();

        // Instancia nuevas
        for (int i = 0; i < opciones.Length; i++)
        {
            var nuevoObjeto = Instantiate(btnOpciónPrefab, padreOpciones);
            var elemento = nuevoObjeto.GetComponent<ElementoInterfazOpción>();
            Action action = () => EnClicOpción(elemento);
            opcionesActuales.Add(elemento);
            elemento.Iniciar(opciones[i], action);
        }
        StartCoroutine(ActivarOpciones());
    }

    private IEnumerator ActivarOpciones()
    {
        yield return new WaitForSeconds(tiempoOpciones);

        foreach (var elemento in opcionesActuales)
        {
            elemento.ActivarBotón();
        }
    }

    public void EnClicOpción(ElementoInterfazOpción opcion)
    {
        panelOpciones.SetActive(false);
        opcionesActuales.Clear();
        IniciarDiálogo(opcion.dialogo);
    }

    private void FinalizarPartida(TipoFinal tipoFinal)
    {
        print("final " + tipoFinal);
    }
}
