using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class HighScoreScript : MonoBehaviour
{
    public float HighScore;
    public float CurrentTime;
    public Text HighScoreText;
    public Text SurvivedTime;

    void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore");
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            CurrentTime = 0;
        }
        CurrentTime = Time.timeSinceLevelLoad;

        if (CurrentTime >= HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", CurrentTime);
            HighScoreText.text = "A new high score!";
        }
        SurvivedTime.text = "You Survived for " + CurrentTime + " Seconds";
    }

}