using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollisions : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("OnTiggerEnter2D", 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collisions with none enemy objects destroy laser only
        if (collision.gameObject.tag == "World" || collision.gameObject.tag == "Inner Barrier" || collision.gameObject.tag == "Planet")
        {
            Destroy(this.gameObject);
        }

        //Collisions with Enemies destroys both the laser and the enemy
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
    void OnDisable()
    {
        CancelInvoke(); //When the laser is diabled stop checking for collisions
    }
}