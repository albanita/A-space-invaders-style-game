using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Alien_Collision : MonoBehaviour
{
    private AudioFX audioFX;
    public GameObject [] aliens;
    public Text txtGameOver;
    public Text txtTryAgain;
    public Text txtBackMenu;
    public Text txtVictory;
    public Text txtChallangeBoss;

    private void Start()
    {
        audioFX = GameObject.Find("AudioFX").GetComponent<AudioFX>();
        aliens = GameObject.FindGameObjectsWithTag("Enemy");
        AlienControl.num = aliens.Length;
    }

    private void Update()
    {
        if(AlienControl.num == 0)
        {
            victory();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<AlienControl>() != null)
        {
            defeat();
        }
    }

    private void victory()
    {
        txtVictory.GetComponent<Text>().enabled = true;
        txtTryAgain.text = "Play Again";
        txtTryAgain.GetComponent<Text>().enabled = true;
        txtBackMenu.GetComponent<Text>().enabled = true;
        txtChallangeBoss.GetComponent<Text>().enabled = true;
    }

    public void defeat()
    {
        audioFX.playExplosion();
        Destroy(gameObject);
        txtGameOver.GetComponent<Text>().enabled = true;
        txtTryAgain.GetComponent<Text>().enabled = true;
        txtBackMenu.GetComponent<Text>().enabled = true;
    }
}
