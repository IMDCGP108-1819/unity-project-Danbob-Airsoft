using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    private Camera GameOverCamera;
    private CanvasGroup GameOverCanvas;
    public Camera PlayerCam;
    private GameObject Spawner;
    private GameObject Capital;

    public void Start()
    {
        GameOverCamera = GameObject.Find("GameOverCamera").GetComponent<Camera>();
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
        Spawner = GameObject.Find("Enemy Spawn Controller");
        Capital = GameObject.Find("Capital Ship Spawn");
        PlayerCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "CapitalShip" || collision.gameObject.tag == "EnemyLaser")
        {
            //Reduces health on collision with enemies
            Health -= 1;
            
            if (Health == 0)
            {
                //Enables and Switches to Game over canvas
                PlayerCam.enabled = false;
                GameOverCanvas.alpha = 1f;
                GameOverCamera.enabled = true;
                Destroy(this.gameObject);
                Destroy(Spawner.gameObject); //Destroys the enemy spawner, preventing enemies from spawning after game over
                Destroy(Capital.gameObject);
                GameOverCanvas.interactable = true;
                GameOverCanvas.blocksRaycasts = true;
                Time.timeScale = 0;
            }
            if (collision.gameObject.tag == "Enemy")
            {
                //Disables enemy ships ONLY
                collision.gameObject.SetActive(false);
            }
                
        }
    }
}
