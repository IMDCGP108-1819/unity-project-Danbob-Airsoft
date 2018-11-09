using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    public Button PlayButton;
    public Button HowToPlay;
    public Button QuitButton;

    public CanvasGroup MainMenuGroup;
    public CanvasGroup HowToPlayGroup;

    public void QuitGame()
    {
        Application.Quit();
    }
}
