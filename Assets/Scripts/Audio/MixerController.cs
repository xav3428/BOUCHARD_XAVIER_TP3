using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audiomixer;

    public void SetMainVolume(float slidervalue)
    {
        audiomixer.SetFloat("mainvolume", Mathf.Log10(slidervalue) * 20);
    }
    public void SetMusicVolume(float slidervalue)
    {
        audiomixer.SetFloat("musicvolume", Mathf.Log10(slidervalue) * 20);
    }
    public void SetEffectsVolume(float slidervalue)
    {
        audiomixer.SetFloat("effectvolume", Mathf.Log10(slidervalue) * 20);
    }
}
