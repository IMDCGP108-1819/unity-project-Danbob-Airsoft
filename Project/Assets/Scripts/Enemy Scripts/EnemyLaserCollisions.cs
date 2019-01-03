using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserCollisions : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for collisions with world objects or player
        if (collision.gameObject.tag == "Outer Barrier" || collision.gameObject.tag == "Inner Barrier" || collision.gameObject.tag == "World" || collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        //Check for collision with enemy ships
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject); //Destory Laser
            collision.gameObject.SetActive(false); //Disable enemy ship
        }
    }
}
