using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
    }
}