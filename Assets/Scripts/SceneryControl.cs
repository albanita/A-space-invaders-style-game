using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneryControl : MonoBehaviour
{

    public Sprite [] poze;
    private Image fond;

    // Start is called before the first frame update
    void Start()
    {
        fond = GameObject.Find("Fond").GetComponent<Image>();
        int num = Random.Range(0,poze.Length);
        fond.sprite = poze[num];
    }
}
