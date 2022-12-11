using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerScore01 = 0;
    public static int playerScore02 = 0;
    public GUISkin theSkin;
    public Transform theBall;
    public static bool ShowResetButton = false;
    public static bool ShowFinalScoreButton = true;
    public static bool ShowExitButton = false;


    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;

    }

    public static void InitialStateGM()
    {
        ShowResetButton = false;
        ShowFinalScoreButton = true;
        ShowExitButton = false;
}
    public static void setZeroScores()
    {
        playerScore01 = 0;
        playerScore02 = 0;
    }

    public static int[] Score(string wallName)
    {
        if (wallName == "rightWall")
        {
            playerScore01 += 1;
        }
        else if (wallName == "leftWall")
        {
            playerScore02 += 1;
        }
        //Debug.Log("Player Score 1 is : " + playerScore01);
        //Debug.Log("Player Score 2 is : " + playerScore02); 
         int[] scores;
        scores = new int[2];
        scores[0] = playerScore01;
        scores[1] = playerScore02;
        return scores;
    }
    void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150, 25, 100, 100), "" + playerScore01);
        GUI.Label(new Rect(Screen.width / 2 + 150, 25, 100, 100), "" + playerScore02);

        if (ShowExitButton)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 121 / 2, Screen.height - 35-53/2, 121, 53), "Exit"))
            {
                playerScore01 = 0;
                playerScore02 = 0;

                theBall.gameObject.SendMessage("InitialState");
                ShowResetButton = false;
                ShowFinalScoreButton = true;
                ShowExitButton = false;

            }
        }

        if (ShowResetButton)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 121 / 2, 35, 121, 53), "Reset"))
            {
                playerScore01 = 0;
                playerScore02 = 0;

                theBall.gameObject.SendMessage("ResetBall");
            }

        }

        if (ShowFinalScoreButton)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 141, 200, 53), "Start - 50"))
            {
                playerScore01 = 0;
                playerScore02 = 0;
                SideWalls.setEndScore_50();
                theBall.gameObject.SendMessage("GoBall");
                ShowResetButton = true;
                ShowFinalScoreButton = false;
                ShowExitButton = true;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 194, 200, 53), "Start - 100"))
            {
                playerScore01 = 0;
                playerScore02 = 0;
                SideWalls.setEndScore_100();
                theBall.gameObject.SendMessage("GoBall");
                ShowResetButton = true;
                ShowFinalScoreButton = false;
                ShowExitButton = true;
            }
        }

        
    }
}
