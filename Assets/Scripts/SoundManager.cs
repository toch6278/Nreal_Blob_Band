using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst; 
    public float[] spectrumWidth; 
    AudioSource audioSource; 

    void Awake()
    {
        spectrumWidth = new float[64]; 
        audioSource = GetComponent<AudioSource>(); 
        inst = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData(spectrumWidth, 0, FFTWindow.Blackman); 
    }

    public float getFrequency (int start, int end, int mult)
    {
        return spectrumWidth.ToList().GetRange(start,end).Average() * mult;
    }
}
