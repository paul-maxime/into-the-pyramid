using UnityEngine;

public class LightSpell : MonoBehaviour
{
    void Awake()
    {
        RenderSettings.ambientIntensity = 0.02f;
        RenderSettings.ambientGroundColor = new Color(0.45f, 0.40f, 0.35f);
        RenderSettings.ambientEquatorColor = RenderSettings.ambientGroundColor;
        RenderSettings.ambientSkyColor = RenderSettings.ambientGroundColor;
        RenderSettings.fog = true;
        RenderSettings.fogColor = new Color(0.07f, 0.06f, 0.05f);
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.18f;
    }

    void OnEnable()
    {
        RenderSettings.ambientIntensity = 0.92f;
        RenderSettings.fogColor = new Color(0.14f, 0.12f, 0.1f);
        RenderSettings.fogDensity = 0.06f;
        GameObject spotlight = GameObject.Find("Spotlight");
        if (spotlight != null)
        {
            spotlight.GetComponent<Light>().enabled = false;
        }
    }
}
