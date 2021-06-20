using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    GameObject laserBullet;

    private void Start()
    {
        laserBullet = GameObject.Find("Laser");
    }

    private void Update()
    {
        shoot();
        move();
    }

    private void shoot(){
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject myClone = Instantiate(laserBullet) as GameObject;
            StartCoroutine(releaseObject(3, myClone));
        }
    }

    IEnumerator releaseObject(int sec, GameObject go){
        yield return new WaitForSeconds(sec);
        Destroy(go);
    }

    private void move(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            gameObject.transform.Translate(Vector2.left*Time.deltaTime*10);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            gameObject.transform.Translate(Vector2.right*Time.deltaTime*10);
        }
    }
}
