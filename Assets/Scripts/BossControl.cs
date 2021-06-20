using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    private AudioFX audioFX;
    public Text txtLife;
    public Text txtTimer;
    public endGame end;
    public int life;
    public float time;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        audioFX = GameObject.Find("AudioFX").GetComponent<AudioFX>();
        txtLife.GetComponent<Text>().text = life.ToString();
        txtTimer.GetComponent<Text>().text = time.ToString();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 0){
            end.victory();
            audioFX.playExplosion();
            Destroy(gameObject);
        }
        cronometer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<LaserControl>() != null)
        {
            audioFX.playExplosion();
            life--;
            txtLife.GetComponent<Text>().text = life.ToString();
        }
    }

    private void cronometer()
    {
        if(time <= 0f){
            end.defeat();
            Destroy(player);
        }
        else{
            time -= Time.deltaTime;
            if(time <= 5){
                txtTimer.GetComponent<Text>().color = Color.red;
            }
            txtTimer.GetComponent<Text>().text = ((int)time).ToString();
        }
    }
}
