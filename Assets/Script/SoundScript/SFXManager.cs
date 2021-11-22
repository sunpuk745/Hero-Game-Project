using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip PlayerWarp;
    public AudioClip PlayerWalk;
    public AudioClip PlayerAttack;
    public AudioClip PlayerWin;
    public AudioClip ArtoriasWalk;
    public AudioClip ArtoriasAttack1;
    public AudioClip ArtoriasAttack2_1;
    public AudioClip ArtoriasAttack2_2;
    public AudioClip ArtoriasAttack3_1;
    public AudioClip ArtoriasAttack3_2;
    public AudioClip ArtoriasDie;
    public AudioClip NightWalk;
    public AudioClip NightAttack1;
    public AudioClip NightDie;
    public static SFXManager sfxInstance;

    private void Awake()
    {
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
