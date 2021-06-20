using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienEdgeController : MonoBehaviour
{

    public Text txtGameOver;
    public Text txtTryAgain;
    public Text txtBackMenu;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<AlienControl>() != null){
            defeat();
        }
    }

    private void defeat()
    {
        txtGameOver.GetComponent<Text>().enabled = true;
        txtTryAgain.GetComponent<Text>().enabled = true;
        txtBackMenu.GetComponent<Text>().enabled = true;
    }
}
