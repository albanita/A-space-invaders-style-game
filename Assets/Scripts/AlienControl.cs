using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienControl : MonoBehaviour
{
    private AudioFX audioFX;
    private float velocidad;
    public Transform trm;

    public static int num;

    public Text txtScor;
    
    void Start()
    {
        Iniciar();
    }

    private void Iniciar()
    {
        audioFX = GameObject.Find("AudioFX").GetComponent<AudioFX>();
        trm = gameObject.GetComponent<Transform>();
        int sec = Random.Range(1,3);
        float vel = Random.Range(0.45f, 4);
        StartCoroutine(startMoving(sec, vel));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<LaserControl>() != null)
        {
            audioFX.playExplosion();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        incrementScor();
        num--;
    }

    public void incrementScor()
    {
        if(txtScor != null)
        {
            int scor = int.Parse(txtScor.text);
            scor++;
            txtScor.text = scor.ToString();
        }
    }

    private void Update()
    {
        mover();
    }

    private void mover()
    {
        trm.Translate(Vector2.down * velocidad * Time.deltaTime);
    }

    IEnumerator startMoving(int sec, float vel)
    {
        yield return new WaitForSeconds(sec);
        velocidad = vel;
    }
}
