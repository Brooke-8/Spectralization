using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAudioListener : MonoBehaviour
{
    public float delayTime = 3.0f;

    public AudioSource audioSource;
    private AudioClip delayedClip;
    private float[] delayedSamples;
    private int delayedSamplePos;

    void Start()
    {
       
    }

    void Update()
    {
        
    }
}
