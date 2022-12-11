using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    private Transform tr2D;
    public static int endScore;

    public static void setEndScore_100()
    {
        endScore = 100;
    }

    public static void setEndScore_50()
    {
        endScore = 50;
    }
    // Start is called before the first frame update
    void Start()
    {
        tr2D = GetComponent<Transform>();
    }
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Ball")
        {
            string wallName = tr2D.name;
            int[] scores;
            scores = GameManager.Score(wallName);
            if (scores[0] >= endScore)
            {
                Debug.Log("Player 1 Win");
                hitInfo.gameObject.SendMessage("InitialState");
            }
            else if (scores[1] >= endScore)
            {
                Debug.Log("Player 2 Win");
                hitInfo.gameObject.SendMessage("InitialState");
            }

        }
    }
}
