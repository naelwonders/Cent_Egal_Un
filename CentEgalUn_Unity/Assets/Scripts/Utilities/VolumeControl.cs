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

    public Sprite soundOnImage;
    public Sprite soundOffImage;

    public Image currentImage;

    private bool soundOn;


    void Start()
    {
        soundOn = true;
        // Ensure the slider value matches the initial volume
        volumeSlider.value = initialVolume;
        // Set the initial volume of the audio source
        audioSource.volume = initialVolume;
        // Add a listener to the slider to update the volume when it changes
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        currentImage.sprite = soundOnImage;
    }

    void ChangeVolume(float volume)
    {
        
        audioSource.volume = volume;
        
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
        if (soundOn)
        {
            audioSource.volume = initialVolume;
            volumeSlider.value = initialVolume;
            currentImage.sprite = soundOnImage;
            //soundOn = false;
        }
        else
        {
            audioSource.volume = 0f;
            volumeSlider.value = 0f;
            currentImage.sprite = soundOffImage;
            //soundOn = true;
        }

        Debug.Log("Sound is now " + (soundOn ? "ON" : "OFF"));
        Debug.Log("Current Sprite: " + currentImage.sprite);
    }
}
