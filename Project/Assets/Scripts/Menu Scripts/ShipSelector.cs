using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShipSelector : MonoBehaviour {
    public CanvasGroup ShipSelectorGroup;
    //Get both playable ship prefabs
    public GameObject StarSkipper;
    public GameObject TX21;
    //Get player spawn point
    public GameObject PlayerSpawn;
    //Get both cameras needed to change scene
    public Camera SelectionCamera;
    public Camera PlayerCam;
    //Get enemy spawners
    public GameObject CapitalSpawner;
    public GameObject ShipSpawner;
    //For later use to store the spawned ship

    private void Start()
    {
        //Find main camera and stop time
        PlayerCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Time.timeScale = 0;
    }

    public void StarSkipperButton() //On button press
    {
        Instantiate(StarSkipper,PlayerSpawn.transform.position, PlayerSpawn.transform.rotation);
        //Creats the faster Player prefab on the Spawn game object
        //Hides ship selection menu
        ShipSelectorGroup.alpha = 0f;
        ShipSelectorGroup.interactable = false;
        ShipSelectorGroup.blocksRaycasts = false;
        //Gets the camera on the main game and enables it while disabling the camera displaying the ship selection
        PlayerCam.enabled = true;
        SelectionCamera.enabled = false;
        Time.timeScale = 1; //Starts time

    }

    public void TX21Button()
    {
        Instantiate(TX21, PlayerSpawn.transform.position, PlayerSpawn.transform.rotation);
        //Same as above but spawns the slower ship prefab
        ShipSelectorGroup.alpha = 0f;
        ShipSelectorGroup.interactable = false;
        ShipSelectorGroup.blocksRaycasts = false;
        PlayerCam.enabled = true;
        SelectionCamera.enabled = false;
        Time.timeScale = 1;
    }
}