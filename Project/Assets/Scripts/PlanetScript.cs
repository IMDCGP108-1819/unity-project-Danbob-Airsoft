using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public int PlanetHealth = 2;
    private Camera GameOverCamera;
    private CanvasGroup GameOverCanvas;
    private GameObject Player;
    private GameObject Spawner;
    private GameObject Capital;
    public Camera PlayerCam;
    public AudioSource AudioSource;

    public void Start()
    {
        //Get Canvas'
        GameOverCamera = GameObject.Find("GameOverCamera").GetComponent<Camera>();
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
        Spawner = GameObject.Find("Enemy Spawn Controller");
        Capital = GameObject.Find("Capital Ship Spawn");
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        AudioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CapitalShip")
        {
            //Reduces health on collision with Capital Ship
            PlanetHealth -= 1;

            if (PlanetHealth == 0)
            {
                //Enables and Switches to Game over canvas
                Destroy(Player);
                PlayerCam.enabled = false;
                GameOverCanvas.alpha = 1f;
                GameOverCamera.enabled = true;
                Destroy(Spawner.gameObject); //Destroys the enemy spawner, preventing enemies from spawning after game over
                Destroy(Capital.gameObject);
                Debug.Log("Ship Destroyed");
                GameOverCanvas.interactable = true;
                GameOverCanvas.blocksRaycasts = true;
                Time.timeScale = 0;
            }
        }
    }
}