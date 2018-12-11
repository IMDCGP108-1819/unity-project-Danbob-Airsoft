using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShipSelector : MonoBehaviour {
    public CanvasGroup ShipSelectorGroup;
    public GameObject StarSkipper;
    public GameObject PlayerSpawn;
    public GameObject TX21;
    public Camera SelectionCamera;
    private Camera FastCam;
    private Camera SlowCam;
    public GameObject CapitalSpawner;
    public GameObject ShipSpawner;

    private GameObject SpawnedShip;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StarSkipperButton()
    {
        //Creats the faster Player prefab on the Spawn game object
        SpawnedShip = Instantiate(StarSkipper, PlayerSpawn.transform.position, transform.rotation);
        //Hides ship selection menu
        ShipSelectorGroup.alpha = 0f;
        ShipSelectorGroup.interactable = false;
        ShipSelectorGroup.blocksRaycasts = false;
        //Gets the camera on the spawned ship and enables it while disabling the camera displaying the ship selection
        FastCam = SpawnedShip.GetComponentInChildren<Camera>();
        FastCam.enabled = true;
        SelectionCamera.enabled = false;
        Time.timeScale = 1;

    }

    public void TX21Button()
    {
        //Same as above but spawns the slower ship prefab
        SpawnedShip = Instantiate(TX21, PlayerSpawn.transform.position, transform.rotation);
        ShipSelectorGroup.alpha = 0f;
        ShipSelectorGroup.interactable = false;
        ShipSelectorGroup.blocksRaycasts = false;
        SlowCam = SpawnedShip.GetComponentInChildren<Camera>();
        SlowCam.enabled = true;
        SelectionCamera.enabled = false;
        Time.timeScale = 1;
    }
}