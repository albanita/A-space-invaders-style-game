using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Plugins;

public class endGame : MonoBehaviour
{
    public Text txtBackMenu;
    public Text txtTryAgain;
    public Text txtGameOver;
    public Text txtVictory;

    public void victory(){
        txtVictory.GetComponent<Text>().enabled=true;
        txtTryAgain.GetComponent<Text>().enabled=true;
        txtBackMenu.GetComponent<Text>().enabled=true;
    }

    public void defeat(){
        txtGameOver.GetComponent<Text>().enabled=true;
        txtTryAgain.GetComponent<Text>().enabled=true;
        txtBackMenu.GetComponent<Text>().enabled=true;
    }
}
