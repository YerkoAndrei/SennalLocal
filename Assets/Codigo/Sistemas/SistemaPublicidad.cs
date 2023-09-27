using UnityEngine;
using GoogleMobileAds.Api;

public class SistemaPublicidad : MonoBehaviour
{
    [SerializeField] private bool modoPrueba;
    
    private static SistemaPublicidad instancia;
    public static bool modoMóvil;

    // Intancias
    private BannerView banner;
    private InterstitialAd inter;

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
            CargarInter();
            MostrarBanner();
        }
    }

    private static string ObtenerIdPublicidadBanner()
    {
#if UNITY_ANDROID
        if (instancia.modoPrueba)
            return "ca-app-pub-3940256099942544/6300978111";
        else
            return "ca-app-pub-2409944020661987/3776753669";
#elif UNITY_IOS || UNITY_IPHONE
        if (instancia.modoPrueba)
            return "ca-app-pub-3940256099942544/2934735716";
        else
            return "unused";
#else
        return "unused";
#endif
    }

    private static string ObtenerIdPublicidadInter()
    {
#if UNITY_ANDROID
        if (instancia.modoPrueba)
            return "ca-app-pub-3940256099942544/1033173712";
        else
            return "ca-app-pub-2409944020661987/4941902777";
#elif UNITY_IOS || UNITY_IPHONE
        if (instancia.modoPrueba)
            return "ca-app-pub-3940256099942544/4411468910";
        else
            return "unused";
#else
        return "unused";
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

    // Intersticial
    private static void CargarInter()
    {
        if (!modoMóvil)
            return;

        if (instancia.inter != null)
        {
            instancia.inter.Destroy();
            instancia.inter = null;
        }

        // Carga de publicidad intersticial
        var adRequest = new AdRequest();
        InterstitialAd.Load(ObtenerIdPublicidadInter(), adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Error inter: " + error);
                    return;
                }
                instancia.inter = ad;

                // Vuelve a cargar
                instancia.inter.OnAdFullScreenContentClosed += CargarInter;
            });
    }

    public static void MostrarInter()
    {
        if (!modoMóvil)
            return;

        if (instancia.inter != null && instancia.inter.CanShowAd())
            instancia.inter.Show();
    }
}
