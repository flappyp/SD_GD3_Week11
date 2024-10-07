using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeTest : MonoBehaviour
{
    public Volume volume1;
    DepthOfField dof;
    ColorAdjustments ca;
    Bloom bloom;
    Vignette vignette;
    ChromaticAberration chromaticAberration;

    private bool isDOFEnabled = true;
    private bool isCAEnabled = true;
    private bool isBloomEnabled = true;
    private bool isVignetteEnabled = true;
    private bool isChromaticAberrationEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        volume1.profile.TryGet(out dof);
        volume1.profile.TryGet(out ca);
        volume1.profile.TryGet(out bloom);
        volume1.profile.TryGet(out vignette);
        volume1.profile.TryGet(out chromaticAberration);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (isDOFEnabled && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            dof.focusDistance.value = Vector3.Distance(Camera.main.transform.position, hit.point);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isDOFEnabled = !isDOFEnabled;
            dof.active = isDOFEnabled;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ca.saturation.value = 100f;
            isCAEnabled = !isCAEnabled;
            ca.active = isCAEnabled;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isBloomEnabled = !isBloomEnabled;
            bloom.active = isBloomEnabled;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isVignetteEnabled = !isVignetteEnabled;
            vignette.active = isVignetteEnabled;
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            isChromaticAberrationEnabled = !isChromaticAberrationEnabled;
            chromaticAberration.active = isChromaticAberrationEnabled;
        }
    }
}