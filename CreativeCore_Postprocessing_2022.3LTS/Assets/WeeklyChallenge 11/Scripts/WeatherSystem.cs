using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.VFX;

public class WeatherSystem : MonoBehaviour
{
    [Header("Global")]
    public Material globalMaterial;
    public Light sunLight;
    public Material skyboxMaterial;
    public TMP_Text weatherText;

    [Header("Winter Assets")]
    public VisualEffect winterVFX;
    public Volume winterVolume;

    [Header("Rain Assets")]
    public VisualEffect rainVFX;
    public Volume rainVolume;

    [Header("Autumn Assets")]
    public VisualEffect autumnVFX;
    public Volume autumnVolume;

    [Header("Summer Assets")]
    public VisualEffect summerVFX;
    public Volume summerVolume;

    private VisualEffect currentVFX;

    private void Start()
    {
        winterVFX.Stop();
        rainVFX.Stop();
        autumnVFX.Stop();
        summerVFX.Stop();
    }
  

    public void Winter()
    {
       

        currentVFX = winterVFX;
        winterVFX.Play();
        rainVFX.Stop();
        autumnVFX.Stop();
        summerVFX.Stop();
        winterVolume.weight = 1.0f;
        UpdateSkyboxColor(Color.white);
        sunLight.color = Color.white * 0.9f;

    }

    public void Rain()
    {
       

        currentVFX = rainVFX;
        rainVFX.Play();
        winterVFX.Stop();
        autumnVFX.Stop();
        summerVFX.Stop();
        rainVolume.weight = 1.0f;
        UpdateSkyboxColor(new Color(0.3f, 0.3f, 0.4f));
        sunLight.color = Color.gray;
    }

    public void Autumn()
    {
        

        currentVFX.Play();
        autumnVFX.Play();
        autumnVolume.weight = 1.0f;
        UpdateSkyboxColor(new Color(0.8f, 0.6f, 0.4f));
        sunLight.color = new Color(1f, 0.9f, 0.7f);
    }

    public void Summer()
    {
        
        currentVFX = summerVFX;
        summerVFX.Play();
        summerVolume.weight = 1.0f;
        UpdateSkyboxColor(Color.cyan);
        sunLight.color = Color.yellow;
    }

    private void UpdateSkyboxColor(Color color)
    {
        skyboxMaterial.SetColor("_Tint", color);
    }
}
