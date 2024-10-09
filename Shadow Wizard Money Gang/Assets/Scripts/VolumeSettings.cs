using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider musicSlider;
    public Toggle sfxToggle;
    public AudioSource backgroundMusic;

    public Audio audio;
    public void SetVolume()
    {
        float volume = musicSlider.value;
        backgroundMusic.volume = volume;
    }

    public void ToggleSFX()
    {
        bool isOn = sfxToggle.isOn;
        audio.canPlay = isOn;
    }
}
