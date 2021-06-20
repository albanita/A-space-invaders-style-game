using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    private Interactions itr;
    // Start is called before the first frame update
    void Start()
    {
        itr = gameObject.GetComponent<Interactions>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            itr.returnToMenu();
        }
    }
}
