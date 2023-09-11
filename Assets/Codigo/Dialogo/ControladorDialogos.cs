// YerkoAndrei
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    [SerializeField] private float tiempoElegirOpción;
    [SerializeField] private float tiempoEsperaAutomático;

    [Header("Colores Menú")]
    [SerializeField] private Color colorCargando;
    [SerializeField] private Color colorContinuar;
    [SerializeField] private Color colorPanelActivo;
    [SerializeField] private Color colorPanelEspera;

    [Header("Referencias diálogos")]
    [SerializeField] private GameObject panelDiálogos;
    [SerializeField] private Image panelOscuro;
    [SerializeField] private Image panelDiálogo;
    [SerializeField] private TMP_Text txtDiálogo;
    [SerializeField] private Image imgPersonaje;
    [SerializeField] private Image imgContinuar;
    [SerializeField] private GameObject imgVisto;

    [Header("Referencias opciones")]
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private Transform padreOpciones;
    [SerializeField] private ContentSizeFitter tamañoContenido;
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

    [Header("Colores Menú")]
    [SerializeField] private Color colorUsuario;
    [SerializeField] private Color colorOperador;
    [SerializeField] private Color colorMonstruo;
    [SerializeField] private Color colorSobreviviente;
    [SerializeField] private Color colorComputador;

    [Header("Animaciones")]
    [SerializeField] private RectTransform rectDiálogos;
    [SerializeField] private RectTransform rectInteractuables;

    private ControladorCamara controladorCamara;

    private ElementoDialogo diálogoActual;
    private List<ElementoInterfazOpcion> opcionesActuales;
    private Animaciones animaciónMostrada;
    private bool iniciado;
    private bool automático;
    private bool activo;
    private bool mostrandoTexto;
    private bool puedeContinuar;
    private bool carácterDeEtiqueta;
    private bool carácterEnTextoRico;
    private float contadorTiempo;
    private float tiempoDiálogo;

    private const char carácterEtiqueta = '#';

    private void Start()
    {
        Iniciar();
    }

    public void Iniciar()
    {
        panelDiálogos.SetActive(false);
        panelOpciones.SetActive(false);
        panelPregunta.SetActive(false);
        VerImagenContinuar(false);

        controladorCamara = FindObjectOfType<ControladorCamara>();
        opcionesActuales = new List<ElementoInterfazOpcion>();

        // Estados limpios
        estado = Estados.enPausa;
        txtDiálogo.text = string.Empty;
        imgContinuar.color = Color.clear;
        panelDiálogo.color = colorPanelEspera;
        imgPersonaje.gameObject.SetActive(false);
        imgVisto.SetActive(false);

        foreach (Transform hijo in padreOpciones)
        {
            Destroy(hijo.gameObject);
        }
    }

    public void ComenzarJuego()
    {
        estado = Estados.mostrandoAnimación;
        animaciónMostrada = Animaciones.nada;

        // Primer Flujo
        if (!iniciado)
        {
            controladorCamara.CambiarPosición(CámarasCine.inicio);
            SistemaAnimacion.MostrarAnimación(Animaciones.sentarse);
        }

        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.bajo);
        ControladorRadio.ApagarNombreRuta();

        StopAllCoroutines();
        StartCoroutine(MostrarIntroducción());

        iniciado = true;
    }

    private IEnumerator MostrarIntroducción()
    {
        if (!iniciado)
        {
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => activo);
        }
        else
            controladorCamara.CambiarPosición(CámarasCine.juego);

        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => activo);

        var intro = new RutaIntro();
        IniciarDiálogo(intro.CrearIntro_0());
    }

    private void Update()
    {
        // Llenado imagen continuar
        if (!puedeContinuar)
        {
            contadorTiempo += Time.deltaTime;
            imgContinuar.fillAmount = contadorTiempo / tiempoDiálogo;
        }

        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Escape) && !panelPregunta.activeSelf)
            EnClic();
    }

    public void EnClic()
    {
        // Finales
        if (SistemaAnimacion.mostrandoAnimación)
            return;

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
        SistemaMemoria.MarcarDiálogo(diálogoActual.texto);

        estado = Estados.mostrandoDiálogo;
        imgVisto.SetActive(diálogoActual.visto);
        mostrandoTexto = true;
        puedeContinuar = false;

        txtDiálogo.text = string.Empty;
        imgPersonaje.gameObject.SetActive(true);
        panelDiálogo.color = colorPanelActivo;

        if (!panelDiálogos.activeSelf)
        {
            panelDiálogos.SetActive(true);
            SistemaAnimacion.AnimarPanel(rectDiálogos, 0.2f, true, true, Direcciones.abajo, null);
        }

        // Cambio de fuentes
        switch (diálogoActual.personaje)
        {
            case Personajes.usuario:
                txtDiálogo.font = fuenteUsuario;
                txtDiálogo.color = colorUsuario;
                imgPersonaje.sprite = imagenUsuario;
                imgPersonaje.color = colorUsuario;
                break;
            case Personajes.operador:
                txtDiálogo.font = fuenteOperador;
                txtDiálogo.color = colorOperador;
                imgPersonaje.sprite = imagenOperador;
                imgPersonaje.color = colorOperador;
                break;
            case Personajes.monstruo:
                txtDiálogo.font = fuenteMonstruo;
                txtDiálogo.color = colorMonstruo;
                imgPersonaje.sprite = imagenMonstruo;
                imgPersonaje.color = colorMonstruo;
                break;
            case Personajes.sobreviviente:
                txtDiálogo.font = fuenteSobreviviente;
                txtDiálogo.color = colorSobreviviente;
                imgPersonaje.sprite = imagenSobreviviente;
                imgPersonaje.color = colorSobreviviente;
                break;
            case Personajes.computador:
                txtDiálogo.font = fuenteComputador;
                txtDiálogo.color = colorComputador;
                imgPersonaje.sprite = imagenComputador;
                imgPersonaje.color = colorComputador;
                break;
        }

        ActivarEfectos();
        VerImagenContinuar(false);

        // Excepción animaciones
        if (diálogoActual.animación != Animaciones.nada)
        {
            panelDiálogos.SetActive(false);
            animaciónMostrada = diálogoActual.animación;
            SistemaAnimacion.MostrarAnimación(diálogoActual.animación);
            TerminarTexto();
        }
        else
        {
            var textoReal = SistemaTraduccion.ObtenerTraducción(diálogoActual.texto);
            ContarTiempoDiálogo(textoReal);
            StartCoroutine(MostrarTexto(textoReal));
        }
    }

    private void ApurarDiálogo()
    {
        if (mostrandoTexto && txtDiálogo.text.Length > 1 && !puedeContinuar && diálogoActual.visto)
            TerminarTexto();
    }

    private void ContarTiempoDiálogo(string texto)
    {
        // Cuánto tiempo se demorará (texto rico se reemplaza por carácterEtiqueta)
        tiempoDiálogo = 0;
        var textoLimpio = ReemplazarEtiquetas(texto);

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

    private IEnumerator MostrarTexto(string texto)
    {
        // Maneja texto rico
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
                        SistemaSonidos.ActivarSonidoPersonaje(diálogoActual.personaje);
                        yield return new WaitForSeconds(tiempoLetraEtiquetada);
                        yield return new WaitUntil(() => activo);
                        continue;
                    }

                    // Pausa según carácter
                    switch (texto[i])
                    {
                        default:
                            SistemaSonidos.ActivarSonidoPersonaje(diálogoActual.personaje);
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
        txtDiálogo.text = SistemaTraduccion.ObtenerTraducción(diálogoActual.texto);
        VerImagenContinuar(true);

        // Continúa o termina guión
        if (diálogoActual.tipoDiálogo == TipoDiálogo.final)
            estado = Estados.esperandoFinal;
        else
            estado = Estados.esperandoClic;

        if (automático)
            StartCoroutine(EsperarAutomático());
    }

    private IEnumerator EsperarAutomático()
    {
        yield return new WaitForSeconds(tiempoEsperaAutomático);

        if (estado == Estados.esperandoClic)
            ContinuarSiguienteAcción();
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
            case TipoDiálogo.nombre:
            case TipoDiálogo.pregunta:
                IniciarPregunta();
                break;
            case TipoDiálogo.final:
                // Final Especial Usuario
                if (animaciónMostrada == Animaciones.llegaUsuario)
                    StartCoroutine(FinalizarEspecialUsuario(diálogoActual.tipoFinal, diálogoActual.ruta));
                else
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

        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.bajo);
        estado = Estados.mostrandoOpciones;
        panelOpciones.SetActive(true);
        SistemaAnimacion.AnimarPanel(rectInteractuables, 0.3f, true, true, Direcciones.izquierda, null);

        // Posición aleatoria
        var opciones = diálogoActual.opciones.OrderBy(x => aleatorio.Next()).ToArray();

        // Tamaño para cuando sean más de 4 preguntas
        if (opciones.Length >= 4)
            tamañoContenido.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        else
        {
            tamañoContenido.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            padreOpciones.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            padreOpciones.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        }

        // Instancia nuevas
        for (int i = 0; i < opciones.Length; i++)
        {
            // Verifica que respuesta exista
            if (!SistemaMemoria.ObtenerRespuestaClave(opciones[i].respuestaClave))
                continue;

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
            elemento.ActivarBotón(true);
        }
    }

    public void EnClicOpción(ElementoInterfazOpcion opcion)
    {
        foreach (var elemento in opcionesActuales)
        {
            elemento.ActivarBotón(false);
        }

        LimpiarInterfaz();

        SistemaAnimacion.AnimarPanel(rectInteractuables, 0.1f, false, false, Direcciones.izquierda, () => panelOpciones.SetActive(false));
        opcionesActuales.Clear();

        SistemaMemoria.MarcarOpción(opcion.texto);
        SistemaAnimacion.MostrarAnimación(Animaciones.escribir);

        // Repite diálogo elegido y continúa
        var diálogoElegido = new ElementoDialogo();
        diálogoElegido.personaje = Personajes.operador;
        diálogoElegido.tipoDiálogo = TipoDiálogo.diálogo;
        diálogoElegido.texto = opcion.texto;
        diálogoElegido.visto = opcion.yaElegido;
        diálogoElegido.nivelEstrés = NivelEstrés.bajo;
        diálogoElegido.ruta = opcion.siguienteDiálogo.ruta;
        diálogoElegido.siguienteDiálogo = opcion.siguienteDiálogo;

        StartCoroutine(SeguirDiálogoOpción(diálogoElegido));
    }

    private IEnumerator SeguirDiálogoOpción(ElementoDialogo diálogoElegido)
    {
        yield return new WaitForSeconds(tiempoElegirOpción);
        IniciarDiálogo(diálogoElegido);
    }

    private void IniciarPregunta()
    {
        estado = Estados.mostrandoPregunta;
        panelPregunta.SetActive(true);
        SistemaAnimacion.AnimarPanel(rectInteractuables, 0.3f, true, true, Direcciones.izquierda, null);
    }

    public void EnClicTerminarPregunta()
    {
        LimpiarInterfaz();

        SistemaAnimacion.AnimarPanel(rectInteractuables, 0.3f, false, false, Direcciones.izquierda, () => panelPregunta.SetActive(false));
        var respuestaVálida = false;

        //  Verificar nombre o pregunta válida
        if (diálogoActual.tipoDiálogo == TipoDiálogo.nombre)
        {
            respuestaVálida = (inputPregunta.text.Length > 3);
            if (respuestaVálida)
                SistemaMemoria.GuardarNombre(inputPregunta.text);
        }
        else if (diálogoActual.tipoDiálogo == TipoDiálogo.pregunta)
            respuestaVálida = SistemaTraduccion.VerificarPreguntaVálida(inputPregunta.text);

        if (respuestaVálida)
            IniciarDiálogo(diálogoActual.siguienteDiálogo);
        else
            IniciarDiálogo(diálogoActual.siguienteDiálogoNegativo);
    }

    private void LimpiarInterfaz()
    {
        txtDiálogo.text = string.Empty;
        imgContinuar.color = Color.clear;
        panelDiálogo.color = colorPanelEspera;
        imgPersonaje.gameObject.SetActive(false);
        imgVisto.SetActive(false);
    }

    public void ActivarEfectos()
    {
        ControladorRadio.CambiarNombreRuta(diálogoActual.ruta);
        ControladorOsciloscopio.CambiarNivelEstrés(diálogoActual.nivelEstrés);
    }

    // MenúController
    public bool ActivarAutomático()
    {
        automático = !automático;

        if (automático && estado == Estados.esperandoClic)
            StartCoroutine(EsperarAutomático());

        return automático;
    }

    private void FinalizarPartida(TipoFinal tipoFinal, Rutas ruta)
    {
        var diálogoFinal = new ElementoDialogo();
        diálogoFinal.personaje = Personajes.operador;
        diálogoFinal.tipoDiálogo = TipoDiálogo.final;
        diálogoFinal.ruta = ruta;

        switch (tipoFinal)
        {
            case TipoFinal.muerte:
                diálogoFinal.texto = "final_muerte";
                diálogoFinal.nivelEstrés = NivelEstrés.muerto;
                break;
            case TipoFinal.captura:
                diálogoFinal.texto = "final_captura";
                diálogoFinal.nivelEstrés = NivelEstrés.bajo;
                break;
            case TipoFinal.escape:
                diálogoFinal.texto = "final_escape";
                diálogoFinal.nivelEstrés = NivelEstrés.bajo;
                break;
        }

        SistemaMemoria.MarcarFinal(diálogoActual.texto, tipoFinal);
        SistemaAnimacion.MostrarAnimación(Animaciones.soloEfectos);
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

        if (mostrar)
            MostrarPanelesFijo(mostrar);

        SistemaAnimacion.AnimarPanel(rectDiálogos, 0.2f, mostrar, true, Direcciones.abajo, null);
        SistemaAnimacion.AnimarPanel(rectInteractuables, 0.3f, mostrar, true, Direcciones.izquierda, () => MostrarPanelesFijo(mostrar));
    }

    private void MostrarPanelesFijo(bool mostrar)
    {
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
        // Finales especiales
        switch(animaciónMostrada)
        {
            case Animaciones.llegaUsuario:
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
                return;
            case Animaciones.finalAutor:
                ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.muerto);
                SistemaAnimacion.MostrarAnimación(Animaciones.cierreAutor);
                return;
            case Animaciones.miraManos:
                SistemaAnimacion.CancelarAnimación();
                break;
        }

        // Volver a Menú
        controladorCamara.CambiarPosición(CámarasCine.final);
        panelDiálogos.SetActive(false);
        panelOpciones.SetActive(false);
        panelPregunta.SetActive(false);

        estado = Estados.enPausa;
        SistemaAnimacion.MostrarAnimación(Animaciones.nada);
        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.muerto);
        ControladorRadio.CambiarNombreRuta(Rutas.menú);
    }

    // Final Especial Usuario
    private IEnumerator FinalizarEspecialUsuario(TipoFinal tipoFinal, Rutas ruta)
    {
        panelOscuro.gameObject.SetActive(true);
        SistemaAnimacion.AnimarColor(panelOscuro, 1, false, Color.clear, Color.black, null);

        yield return new WaitForSeconds(1);
        SistemaSonidos.ReproducirAnimación(Sonidos.matarUsuario);

        yield return new WaitForSeconds(1);
        FinalizarPartida(tipoFinal, ruta);
    }
}
