using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip [] fxs;
    public AudioSource audioS;

    void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
    }

    // 0 laser
    public void playLaser()
    {
        audioS.clip = fxs[0];
        audioS.Play();
    }

    // explosion
    public void playExplosion()
    {
        audioS.clip = fxs[1];
        audioS.Play();
    }

    public void playMenu()
    {
        audioS.clip = fxs[2];
        audioS.Play();
    }

    public void playBeep(){
        audioS.clip = fxs[3];
        audioS.Play();
    }
}
