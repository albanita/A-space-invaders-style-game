using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public Transform trm;
    private int velocidad;

    public bool upDirection;
    public GameObject owner;

    private AudioFX audioFX;
    void Start()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            velocidad=20;
            iniciar();
            StartCoroutine(stopBullet(10));
        }
        if(upDirection == false){
            velocidad = velocidad*-1;
        }
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector2.up*velocidad*Time.deltaTime);
    }

    private void iniciar(){
        audioFX = GameObject.Find("AudioFX").GetComponent<AudioFX>();
        audioFX.playLaser();
        this.trm = owner.GetComponent<Transform>();
        gameObject.transform.position = this.trm.position;
    }

    IEnumerator stopBullet(int sec){
        yield return new WaitForSeconds(sec);
        velocidad=0;
    }
}
