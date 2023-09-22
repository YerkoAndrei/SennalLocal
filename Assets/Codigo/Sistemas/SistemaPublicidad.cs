using UnityEngine;
using GoogleMobileAds.Api;

public class SistemaPublicidad : MonoBehaviour
{
    [SerializeField] private bool modoPrueba;
    
    private static SistemaPublicidad instancia;
    private static bool modoMóvil;

    // Intancias
    private BannerView banner;
    private RewardedAd recompensado;

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
#if UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
        modoMóvil = true;
#endif
        if (modoMóvil)
        {
            MobileAds.Initialize(initStatus => { });
            CargarRecomensado();
            MostrarBanner();
        }
    }

    private static string ObtenerIdPublicidadBanner()
    {
#if UNITY_ANDROID
        if (instancia.modoPrueba)
            return "ca-app-pub-3940256099942544/6300978111";
        else
            return "";
#elif UNITY_IOS || UNITY_IPHONE
        if (instancia.modoPrueba)
            return "ca-app-pub-3940256099942544/2934735716";
        else
            return "";
#else
        return "unexpected_platform";
#endif
    }

    private static string ObtenerIdPublicidadRecompensado()
    {
#if UNITY_ANDROID
        if (instancia.modoPrueba)
            return "ca-app-pub-3940256099942544/5224354917";
        else
            return "";
#elif UNITY_IOS || UNITY_IPHONE
        if (instancia.modoPrueba)
            return "ca-app-pub-3940256099942544/1712485313";
        else
            return "";
#else
        return "unexpected_platform";
#endif
    }

    // Banner
    private static void CrearBanner()
    {
        if (instancia.banner != null)
            DestruirBanner();

        instancia.banner = new BannerView(ObtenerIdPublicidadBanner(), AdSize.IABBanner, AdPosition.BottomLeft);
    }

    public static void MostrarBanner()
    {
        if (!modoMóvil)
            return;

        if (instancia.banner == null)
            CrearBanner();

        var adRequest = new AdRequest();
        instancia.banner.LoadAd(adRequest);
    }

    public static void DestruirBanner()
    {
        if (instancia.banner == null || !modoMóvil)
            return;

        instancia.banner.Destroy();
        instancia.banner = null;
    }

    // Recompensado
    private static void CargarRecomensado()
    {
        if (!modoMóvil)
            return;

        if (instancia.recompensado != null)
        {
            instancia.recompensado.Destroy();
            instancia.recompensado = null;
        }

        // Carga de publicidad recompensada
        var adRequest = new AdRequest();
        RewardedAd.Load(ObtenerIdPublicidadRecompensado(), adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Error carga: " + error);
                    return;
                }
                instancia.recompensado = ad;
            });
    }

    public static void MostrarRecomensado()
    {
        if (!modoMóvil)
            return;

        if (instancia.recompensado != null && instancia.recompensado.CanShowAd())
        {
            instancia.recompensado.Show((Reward reward) =>
            {
                // Destruye y vuelve a cargar
                instancia.recompensado.Destroy();
                CargarRecomensado();
            });
        }
    }
}
