using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserCollisions : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Outer Barrier" || collision.gameObject.tag == "Inner Barrier" || collision.gameObject.tag == "World" || collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
