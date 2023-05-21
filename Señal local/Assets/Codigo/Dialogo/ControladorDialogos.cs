// YerkoAndrei
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Constantes;

public class ControladorDialogos : MonoBehaviour
{
    [Header("Estado")]
    [Ocultar] public Estados estado;
    [Ocultar] public Rutas ruta;

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
    [SerializeField] private Color colorPanelActivo;
    [SerializeField] private Color colorPanelEspera;

    [Header("Referencias diálogos")]
    [SerializeField] private GameObject panelDiálogos;
    [SerializeField] private Image panelDiálogo;
    [SerializeField] private TMP_Text txtDiálogo;
    [SerializeField] private Image imgPersonaje;
    [SerializeField] private Image imgContinuar;
    [SerializeField] private GameObject imgVisto;

    [Header("Referencias opciones")]
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private Transform padreOpciones;
    [SerializeField] private GameObject btnOpciónPrefab;

    [Header("Referencias preguntas")]
    [SerializeField] private GameObject panelPregunta;
    [SerializeField] private TMP_InputField inputPregunta;

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

    private SistemaSonidos sistemaSonido;
    private ControladorCamara controladorCamara;

    private ElementoDialogo diálogoActual;
    private List<ElementoInterfazOpcion> opcionesActuales;
    private bool activo;
    private bool mostrandoTexto;
    private bool puedeContinuar;
    private bool carácterDeEtiqueta;
    private bool carácterEnTextoRico;
    private float contadorTiempo;
    private float tiempoDiálogo;

    private const char carácterEtiqueta = '#';

    public void ComenzarJuego()
    {
        panelDiálogos.SetActive(false);
        panelOpciones.SetActive(false);
        panelPregunta.SetActive(false);
        VerImagenContinuar(false);

        sistemaSonido = FindObjectOfType<SistemaSonidos>();
        controladorCamara = FindObjectOfType<ControladorCamara>();

        opcionesActuales = new List<ElementoInterfazOpcion>();
        txtDiálogo.text = string.Empty;

        foreach (Transform hijo in padreOpciones)
        {
            Destroy(hijo.gameObject);
        }

        estado = Estados.mostrandoAnimación;
        controladorCamara.CambiarPosición(CámarasCine.animación);
        ControladorRadio.ApagarNombreRuta();

        StopAllCoroutines();
        StartCoroutine(MostrarIntroducción());
    }

    private IEnumerator MostrarIntroducción()
    {
        // PENDIENTE animar mono y panel
        yield return new WaitForSeconds(2);
        yield return new WaitUntil(() => activo);

        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.bajo);
        controladorCamara.CambiarPosición(CámarasCine.juego);

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

        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Escape))
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
        diálogoActual = _diálogoActual;
        SistemaMemoria.instancia.MarcarDiálogo(diálogoActual.texto);

        estado = Estados.mostrandoDiálogo;
        txtDiálogo.text = string.Empty;
        imgVisto.SetActive(diálogoActual.visto);
        panelDiálogo.color = colorPanelActivo;
        panelDiálogos.SetActive(true);

        ActivarEfectos();
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
                        sistemaSonido.ActivarSonidoPersonaje(diálogoActual.personaje);
                        yield return new WaitForSeconds(tiempoLetraEtiquetada);
                        yield return new WaitUntil(() => activo);
                        continue;
                    }

                    // Pausa según carácter
                    switch (texto[i])
                    {
                        default:
                            sistemaSonido.ActivarSonidoPersonaje(diálogoActual.personaje);
                            yield return new WaitForSeconds(tiempoLetra);
                            yield return new WaitUntil(() => activo);
                            break;
                        case ' ':
                            yield return new WaitForSeconds(tiempoEspacio);
                            yield return new WaitUntil(() => activo);
                            break;
                        case '-':
                            yield return new WaitForSeconds(tiempoGuión);
                            yield return new WaitUntil(() => activo);
                            break;
                        case ',':
                            yield return new WaitForSeconds(tiempoComa);
                            yield return new WaitUntil(() => activo);
                            break;
                        case '.':
                            yield return new WaitForSeconds(tiempoPunto);
                            yield return new WaitUntil(() => activo);
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

        // Continúa o termina guión
        if(diálogoActual.tipoDiálogo == TipoDiálogo.final)            
            estado = Estados.esperandoFinal;
        else
            estado = Estados.esperandoClic;
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
                FinalizarPartida(diálogoActual.tipoFinal, diálogoActual.ruta);
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
        var opciones = diálogoActual.opciones.OrderBy(x => aleatorio.Next()).ToArray();

        // Instancia nuevas
        for (int i = 0; i < opciones.Length; i++)
        {
            var nuevoObjeto = Instantiate(btnOpciónPrefab, padreOpciones);
            var elemento = nuevoObjeto.GetComponent<ElementoInterfazOpcion>();

            Action enClic = () => EnClicOpción(elemento);
            opcionesActuales.Add(elemento);
            elemento.Iniciar(opciones[i], enClic);
        }
        StartCoroutine(ActivarOpciones());
    }

    private IEnumerator ActivarOpciones()
    {
        yield return new WaitForSeconds(tiempoOpciones);
        yield return new WaitUntil(() => activo);

        panelDiálogo.color = colorPanelEspera;
        foreach (var elemento in opcionesActuales)
        {
            elemento.ActivarBotón();
        }
    }

    public void EnClicOpción(ElementoInterfazOpcion opcion)
    {
        panelOpciones.SetActive(false);
        opcionesActuales.Clear();

        SistemaMemoria.instancia.MarcarOpción(opcion.texto);
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

    public void ActivarEfectos()
    {
        if (ruta != diálogoActual.ruta)
        {
            ruta = diálogoActual.ruta;
            SistemaSonidos.ActualizarMúsica(ruta);
        }

        ControladorOsciloscopio.CambiarNivelEstrés(diálogoActual.nivelEstrés);
        ControladorRadio.CambiarNombreRuta(diálogoActual.ruta);
    }

    private void FinalizarPartida(TipoFinal tipoFinal, Rutas ruta)
    {
        var diálogoFinal = new ElementoDialogo();
        diálogoFinal.personaje = Personajes.operador;
        diálogoFinal.tipoDiálogo = TipoDiálogo.final;
        diálogoFinal.ruta = ruta;

        switch (tipoFinal)
        {
            case TipoFinal.huida:
                diálogoFinal.texto = "(Llamada perdida. El usuario ha huido.)";
                diálogoFinal.nivelEstrés = NivelEstrés.bajo;
                break;
            case TipoFinal.muerte:
                diálogoFinal.texto = "(Llamada perdida. El usuario ha muerto.)";
                diálogoFinal.nivelEstrés = NivelEstrés.muerto;
                break;
            case TipoFinal.captura:
                diálogoFinal.texto = "(Llamada perdida. El usuario ha sido capturado.)";
                diálogoFinal.nivelEstrés = NivelEstrés.capturado;
                break;
        }

        SistemaMemoria.instancia.MarcarFinal(diálogoActual.texto, tipoFinal);
        IniciarDiálogo(diálogoFinal);
    }

    public bool ObtenerDisponibilidad()
    {
        switch (estado)
        {
            default:
            case Estados.enPausa:
            case Estados.esperandoClic:
            case Estados.mostrandoDiálogo:
            case Estados.mostrandoOpciones:
            case Estados.mostrandoPregunta:
                return true;
            case Estados.mostrandoAnimación:
            case Estados.esperandoFinal:
                return false;
        }
    }

    public void MostrarPaneles(bool mostrar)
    {
        activo = mostrar;

        switch (estado)
        {
            case Estados.esperandoClic:
            case Estados.mostrandoDiálogo:
                panelDiálogos.SetActive(mostrar);
                break;
            case Estados.mostrandoOpciones:
                panelDiálogos.SetActive(mostrar);
                panelOpciones.SetActive(mostrar);
                break;
            case Estados.mostrandoPregunta:
                panelDiálogos.SetActive(mostrar);
                panelPregunta.SetActive(mostrar);
                break;
            case Estados.esperandoFinal:
                panelDiálogos.SetActive(mostrar);
                panelOpciones.SetActive(mostrar);
                panelPregunta.SetActive(mostrar);
                break;
        }
    }

    private void VolverAlMenú()
    {
        panelDiálogos.SetActive(false);
        panelOpciones.SetActive(false);
        panelPregunta.SetActive(false);

        estado = Estados.enPausa;
        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.pausa);
        ControladorRadio.CambiarNombreRuta(Rutas.menú);

        controladorCamara.CambiarPosición(CámarasCine.final);
    }
}
