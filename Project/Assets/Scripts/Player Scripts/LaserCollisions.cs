using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collisions with none enemy objects destroy laser only
        if (collision.gameObject.tag == "World")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Inner Barrier")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Planet")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}