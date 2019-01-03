using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScoreScript : MonoBehaviour
{
    public float HighScore;
    public float CurrentTime;
    public Text HighScoreText;
    public Text SurvivedTime;

    private void Start()
    {
        //Resets current time
        CurrentTime = 0;
    }

    private void Update()
    {
        //Gets HighScore from Player Prefs which saves over exiting the game
        HighScore = PlayerPrefs.GetFloat("HighScore");
        CurrentTime = (float)Math.Round(Time.time,2); //Rounds the time played to 2 decimal places and stores

        if (CurrentTime >= HighScore) //If the player beats the high score then the current time becomes the new high score
        {
            PlayerPrefs.SetFloat("HighScore", CurrentTime); //Overwride of high score
            HighScoreText.text = "A new high score!"; //Displays on a game over to tell the player about their new high score
        }
        SurvivedTime.text = "You Survived for " + CurrentTime + " Seconds"; //Displays on a game over to tell the player about their survived time
    }
}
