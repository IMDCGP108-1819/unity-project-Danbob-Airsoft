using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {
    public float HighScore;
    public float CurrentTime;
    public Text HighScOreText;
    public Text SurvivedTime;

    private void Start()
    {
        CurrentTime = 0;
    }

    private void Update()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore");
        CurrentTime = Time.time;

        if (CurrentTime >= HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", CurrentTime);
            HighScOreText.text = "A new high score!";
        }
        SurvivedTime.text = "You Survived for " + CurrentTime + " Seconds";
    }

}
