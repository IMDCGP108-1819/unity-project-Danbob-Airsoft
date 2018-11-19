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
    public Camera SlowCam;

    private GameObject SpawnedShip;

    public void StarSkipperButton()
    {
        SpawnedShip = Instantiate(StarSkipper, PlayerSpawn.transform.position, transform.rotation);
        ShipSelectorGroup.alpha = 0f;
        ShipSelectorGroup.interactable = false;
        ShipSelectorGroup.blocksRaycasts = false;
        FastCam = SpawnedShip.GetComponentInChildren<Camera>();
        FastCam.enabled = true;
        SelectionCamera.enabled = false;
    }

    public void TX21Button()
    {
        SpawnedShip = Instantiate(TX21, PlayerSpawn.transform.position, transform.rotation);
        ShipSelectorGroup.alpha = 0f;
        ShipSelectorGroup.interactable = false;
        ShipSelectorGroup.blocksRaycasts = false;
        SlowCam = SpawnedShip.GetComponentInChildren<Camera>();
        SlowCam.enabled = true;
        SelectionCamera.enabled = false;
    }
}