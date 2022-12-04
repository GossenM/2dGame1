using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField] private PostProcessVolume volumeControl;

    private Bloom bloom;
    private Vignette vignette;

    private void Start()
    {
        volumeControl.profile.TryGetSettings(out bloom);
        volumeControl.profile.TryGetSettings(out vignette);
    }
    public void PostProcessOnOff(bool value)
    {
        bloom.active = value;
        vignette.active = value;
    }
}
