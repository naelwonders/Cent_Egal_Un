using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    // Set the initial volume level (e.g., 0.25 for 25%)
    public float initialVolume = 0.25f;

    void Start()
    {
        // Ensure the slider value matches the initial volume
        volumeSlider.value = initialVolume;
        // Set the initial volume of the audio source
        audioSource.volume = initialVolume;
        // Add a listener to the slider to update the volume when it changes
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float volume)
    {
        // Update the audio volume based on the slider value
        audioSource.volume = volume;
    }
}
