using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public CanvasGroup MainMenuGroup;
    public CanvasGroup HowToPlayGroup;
    public CanvasGroup CreditsGroup;

    //Loading next scene on Play Button press
    public void LoadLevel(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void HowToPlay()
    {
        //Chnaging the canvas layers so that the main menu becomes hidden and buttons become uninteractable
        MainMenuGroup.alpha = 0;
        MainMenuGroup.interactable = false;
        MainMenuGroup.blocksRaycasts = false;

        //Changing the canvas layer for the rules to become visable and buttons become interactable.
        HowToPlayGroup.alpha = 1.0f;
        HowToPlayGroup.interactable = true;
        HowToPlayGroup.blocksRaycasts = true;
    }

    public void BackToMenu()
    {
        //Reversal of the HowToPlay Function
        MainMenuGroup.alpha = 1.0f;
        MainMenuGroup.interactable = true;
        MainMenuGroup.blocksRaycasts = true;

        HowToPlayGroup.alpha = 0f;
        HowToPlayGroup.interactable = false;
        HowToPlayGroup.blocksRaycasts = false;

        CreditsGroup.alpha = 0f;
        CreditsGroup.interactable = false;
        CreditsGroup.blocksRaycasts = false;
    }

    public void Credits()
    {
        MainMenuGroup.alpha = 0;
        MainMenuGroup.interactable = false;
        MainMenuGroup.blocksRaycasts = false;

        CreditsGroup.alpha = 1f;
        CreditsGroup.interactable = true;
        CreditsGroup.blocksRaycasts = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}