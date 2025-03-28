using UnityEngine;
using UnityEngine.Rendering;
using static Constantes;

public class SombraDesactivable : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] mallas;
    [SerializeField] private SkinnedMeshRenderer[] mallasCuerpo;

    public void CambiarLuz(Gráficos gráficos)
    {
        switch (gráficos)
        {
            case Gráficos.bajos:
            case Gráficos.medios:
                if (mallas != null)
                {
                    foreach (var malla in mallas)
                    {
                        malla.shadowCastingMode = ShadowCastingMode.Off;
                    }
                }
                if (mallasCuerpo != null)
                {
                    foreach (var malla in mallasCuerpo)
                    {
                        malla.shadowCastingMode = ShadowCastingMode.Off;
                    }
                }
                break;
            case Gráficos.altos:
                if (mallas != null)
                {
                    foreach (var malla in mallas)
                    {
                        malla.shadowCastingMode = ShadowCastingMode.On;
                    }
                }
                if (mallasCuerpo != null)
                {
                    foreach (var malla in mallasCuerpo)
                    {
                        malla.shadowCastingMode = ShadowCastingMode.On;
                    }
                }
                break;
        }
    }
}
