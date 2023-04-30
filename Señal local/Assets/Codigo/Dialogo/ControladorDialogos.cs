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
using static Constantes;

public class ControladorDialogos : MonoBehaviour
{
    [Header("Estado")]
    [Ocultar] [SerializeField] private Estados estado;

    [Header("Tiempos textos")]
    [SerializeField] private float tiempoLetra;
    [SerializeField] private float tiempoLetraEtiquetada;
    [SerializeField] private float tiempoEspacio;
    [SerializeField] private float tiempoGuión;
    [SerializeField] private float tiempoComa;
    [SerializeField] private float tiempoPunto;

    [Header("Tiempos interfaz")]
    [SerializeField] private float tiempoOpciones;

    [Header("Colores")]
    [SerializeField] private Color colorCargando;
    [SerializeField] private Color colorContinuar;

    [Header("Referencias diálogos")]
    [SerializeField] private GameObject panelDiálogos;
    [SerializeField] private TMP_Text txtDiálogo;
    [SerializeField] private Image imgPersonaje;
    [SerializeField] private Image imgContinuar;

    [Header("Referencias opciones")]
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private Transform padreOpciones;
    [SerializeField] private GameObject btnOpciónPrefab;

    [Header("Referencias preguntas")]
    [SerializeField] private GameObject panelPregunta;
    [SerializeField] private TMP_InputField inputPregunta;

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

    private ElementoDialogo diálogoActual;
    private List<ElementoInterfazOpcion> opcionesActuales;
    private bool mostrandoTexto;
    private bool puedeContinuar;
    private bool carácterDeEtiqueta;
    private bool carácterEnTextoRico;
    private float contadorTiempo;
    private float tiempoDiálogo;

    private const char carácterEtiqueta = '#';

    private void Start()
    {
        panelDiálogos.SetActive(false);
        panelOpciones.SetActive(false);
        panelPregunta.SetActive(false);
        VerImagenContinuar(false);

        opcionesActuales = new List<ElementoInterfazOpcion>();
        txtDiálogo.text = string.Empty;

        foreach (Transform hijo in padreOpciones)
        {
            Destroy(hijo.gameObject);
        }

        estado = Estados.mostrandoAnimación;
        StartCoroutine(MostrarIntroducción());
    }

    private IEnumerator MostrarIntroducción()
    {
        // PENDIENTE animar mono y panel
        yield return new WaitForSeconds(2);

        var intro = new RutaIntro();
        IniciarDiálogo(intro.CrearPrimerDiálogo());
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
            case Estados.esperandoFinal:
                VolverAlMenú();
                break;
        }
    }

    private void IniciarDiálogo(ElementoDialogo _diálogoActual)
    {
        estado = Estados.mostrandoDiálogo;
        txtDiálogo.text = string.Empty;
        panelDiálogos.SetActive(true);

        diálogoActual = _diálogoActual;

        ContarTiempoDiálogo();
        StartCoroutine(MostrarTexto());
    }

    private void ApurarDiálogo()
    {
        if (mostrandoTexto && txtDiálogo.text.Length > 1 && !puedeContinuar && diálogoActual.visto)
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
                case '-':
                    tiempoDiálogo += tiempoGuión;
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
                        case '-':
                            yield return new WaitForSeconds(tiempoGuión);
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
        // Siguiente diálogo
        diálogoActual = diálogoActual.siguienteDiálogo;

        switch (diálogoActual.tipoDiálogo)
        {
            case TipoDiálogo.diálogo:
                IniciarDiálogo(diálogoActual);
                break;
            case TipoDiálogo.opciones:
                IniciarOpciones();
                break;
            case TipoDiálogo.pregunta:
                IniciarPregunta();
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
        // Borra anteriores
        foreach (Transform hijo in padreOpciones)
        {
            Destroy(hijo.gameObject);
        }

        estado = Estados.mostrandoOpciones;
        panelOpciones.SetActive(true);

        // Posición aleatoria
        var aleatoria = new Random(ControladorMenu.semilla);
        var opciones = diálogoActual.opciones.OrderBy(x => aleatoria.Next()).ToArray();

        // Instancia nuevas
        for (int i = 0; i < opciones.Length; i++)
        {
            var nuevoObjeto = Instantiate(btnOpciónPrefab, padreOpciones);
            var elemento = nuevoObjeto.GetComponent<ElementoInterfazOpcion>();
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

    public void EnClicOpción(ElementoInterfazOpcion opcion)
    {
        panelOpciones.SetActive(false);
        opcionesActuales.Clear();
        IniciarDiálogo(opcion.siguienteDiálogo);
    }

    private void IniciarPregunta()
    {
        estado = Estados.mostrandoPregunta;
        panelPregunta.SetActive(true);
    }

    public void EnClicTerminarPregunta()
    {
        panelPregunta.SetActive(false);
        IniciarDiálogo(diálogoActual.siguienteDiálogo);
    }

    private void FinalizarPartida(TipoFinal tipoFinal)
    {
        var diálogoFinal = new ElementoDialogo();
        diálogoFinal.personaje = Personajes.operador;

        switch(tipoFinal)
        {
            case TipoFinal.huida:
                diálogoFinal.texto = "(Llamada perdida. El usuario ha huido.)";
                break;
            case TipoFinal.muerte:
                diálogoFinal.texto = "(Llamada perdida. El usuario ha muerto.)";
                break;
            case TipoFinal.captura:
                diálogoFinal.texto = "(Llamada perdida. El usuario ha sido capturado.)";
                break;
        }

        estado = Estados.esperandoFinal;
        IniciarDiálogo(diálogoFinal);
    }

    private void VolverAlMenú()
    {
        panelDiálogos.SetActive(false);
        SistemaEscenas.instancia.CambiarEscena(Escenas.Menu);
    }
}
