using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// referenced Unity Documentation on second AudioExample
public class AudioSound : MonoBehaviour
{
    public GameObject blob1, blob2, blob3;
    public float pitchValue = 1.0f; 
    public AudioClip mySound; 

    private AudioSource audioSource; 
    private float low = 0.75f; 
    private float high = 1.25f; 
    public float tempo; 

    void Awake()
    {
        // blob = GetComponent<GameObject>(); 
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = mySound; 
        audioSource.loop = true; 
    }
    
    void OnGUI()
    {
        if(blob1.activeSelf == true)
        {
            // audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f/low);
            pitchValue = GUI.HorizontalSlider(new Rect(700,350,100,500), pitchValue, low, high); 
            audioSource.pitch = pitchValue;
            // audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f/pitchValue);
        } 
        if(blob2.activeSelf == true)
        {
            pitchValue = GUI.HorizontalSlider(new Rect(100,380,100,500), pitchValue, low, high); 
            audioSource.pitch = pitchValue; 
            // audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f/low);
        }
        if(blob3.activeSelf == true)
        {
            pitchValue = GUI.HorizontalSlider(new Rect(500,350,100,500), pitchValue, low, high); 
            audioSource.pitch = pitchValue; 
        }
    }
}
