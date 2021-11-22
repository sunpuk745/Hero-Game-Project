using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public float delay;
    AudioSource myAudio;
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        Invoke("playAudio", delay);
    }

    void playAudio()
    {
        myAudio.Play();
    }
}
