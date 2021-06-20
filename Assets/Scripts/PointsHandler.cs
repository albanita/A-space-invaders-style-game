using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Plugins;

public class PointsHandler : MonoBehaviour
{

    public Text txtScore;

    private void OnDestroy()
    {
        int score = int.Parse(txtScore.text);
        Debug.Log("Score: " + score);
        Player pl = Persistencia.getActivePlayer();
        if (pl != null)
        {
            Persistencia.updatePoints(pl, score);
        }
    }
}
