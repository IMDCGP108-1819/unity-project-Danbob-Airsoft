using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalShip : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public int MoveSpeed;
    //Boss Health set
    public int BossHealth;
    //Get Laser
    public GameObject CapitalLaser;
    //Get Cannons
    public Transform[] Cannons;
    private bool ShipFire = true;
    public float LaserSpeed;
    private Rigidbody2D rigidBody;
    private GameObject SpawnedLaser;

    //Boss Movement
    public void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Rigidbody2D.AddForce(Vector2.right * MoveSpeed);
    }

    //Boss Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //With Laser (Used here over Laser script for easy access to Ship health
        if (collision.gameObject.tag == "Laser")
        {
            //Reduces health on collision with enemies
            BossHealth -= 1;
            Destroy(collision.gameObject);
            if (BossHealth == 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.tag == "Planet")
        {
            Destroy(this.gameObject);
        }
    }

    void CapitalFire()
    {
        //Choose Random Cannon to fire from
        int CannonsIndex = Random.Range(0, Cannons.Length);

        //Instantiate laser on Random Cannon
        SpawnedLaser = Instantiate(CapitalLaser, Cannons[CannonsIndex].transform.position, Cannons[CannonsIndex].transform.rotation);
        rigidBody = SpawnedLaser.GetComponent<Rigidbody2D>();
        //Fire Laser either up or down depending on side of cannon
        if (Cannons[CannonsIndex].gameObject.tag == "UpperCannon")
        {
            rigidBody.AddForce(Cannons[CannonsIndex].transform.up * LaserSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (Cannons[CannonsIndex].gameObject.tag == "LowerCannon")
        {
            rigidBody.AddForce(-Cannons[CannonsIndex].transform.up * LaserSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    } 

    private IEnumerator CallFiring()
    {
        ShipFire = false;
        CapitalFire();
        yield return new WaitForSeconds(0.050F);
        ShipFire = true;

    }
//Boss Firing Side Cannons
    private void FixedUpdate()
    {
        if (ShipFire == true)
        {
            StartCoroutine(CallFiring());
        }
    }
}
