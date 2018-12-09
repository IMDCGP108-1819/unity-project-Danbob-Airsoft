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
    private Camera PlayerCam;
    private GameObject Spawner;

    public void Start()
    {
        GameOverCamera = GameObject.Find("GameOverCamera").GetComponent<Camera>();
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
        Spawner = GameObject.Find("Enemy Spawn Controller");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health -= 1;
            Destroy(collision.gameObject);
            if (Health == 0)
            {
                PlayerCam = this.GetComponentInChildren<Camera>();
                PlayerCam.enabled = false;
                GameOverCanvas.alpha = 1f;
                GameOverCamera.enabled = true;
                Destroy(this.gameObject);
                Destroy(Spawner.gameObject);
                Debug.Log("Ship Destroyed");
                GameOverCanvas.interactable = true;
                GameOverCanvas.blocksRaycasts = true;
            }
        }
    }
}
