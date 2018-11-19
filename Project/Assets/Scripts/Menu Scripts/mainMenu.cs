using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    public CanvasGroup MainMenuGroup;
    public CanvasGroup HowToPlayGroup;

    public void LoadLevel(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }

        public void BackToMenu()
    {
        MainMenuGroup.alpha = 1.0f;
        MainMenuGroup.interactable = true;
        MainMenuGroup.blocksRaycasts = true;

        HowToPlayGroup.alpha = 0f;
        HowToPlayGroup.interactable = false;
        HowToPlayGroup.blocksRaycasts = false;
    }

    public void HowToPlay()
    {
        MainMenuGroup.alpha = 0;
        MainMenuGroup.interactable = false;
        MainMenuGroup.blocksRaycasts = false;

        HowToPlayGroup.alpha = 1.0f;
        HowToPlayGroup.interactable = true;
        HowToPlayGroup.blocksRaycasts = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
