using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalShip : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    //Move Speed set
    public int MoveSpeed;
    //Boss Health set
    public int BossHealth;
    //Get Laser
    public GameObject CapitalLaser;
    //Get Cannons
    public Transform[] Cannons;
    //Create bool to allow/ prevent ship from firing
    private bool ShipFire = true;
    //Set Laser Speed
    public float LaserSpeed;
    //Get Laser rigidbody
    private Rigidbody2D LaserrigidBody;
    //Get Laser
    private GameObject SpawnedLaser;
    //Get Audio features
    public AudioSource AudioSource;
    public AudioClip LaserClip;

    public void Start()
    {
        //Set Laser clip to correct file
        AudioSource.clip = LaserClip;
    }

    //Boss Movement (Only moves right)
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
            Destroy(this.gameObject); //Destroys ship and triggers planet script to lower planet health
        }
    }

    void CapitalFire()
    {
        //Choose Random Cannon to fire from
        int CannonsIndex = Random.Range(0, Cannons.Length);

        //Instantiate laser on Random Cannon
        SpawnedLaser = Instantiate(CapitalLaser, Cannons[CannonsIndex].transform.position, Cannons[CannonsIndex].transform.rotation);
        LaserrigidBody = SpawnedLaser.GetComponent<Rigidbody2D>();
        //Fire Laser either up or down depending on side of cannon
        if (Cannons[CannonsIndex].gameObject.tag == "UpperCannon")
        {
            LaserrigidBody.AddForce(Cannons[CannonsIndex].transform.up * LaserSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (Cannons[CannonsIndex].gameObject.tag == "LowerCannon")
        {
            LaserrigidBody.AddForce(-Cannons[CannonsIndex].transform.up * LaserSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        //If the firing sound has ended then replay sound
        if (!AudioSource.isPlaying) AudioSource.Play();

    } 

    private IEnumerator CallFiring()
    {
        ShipFire = false; //Disable firing till complete
        CapitalFire(); //Fire laser
        yield return new WaitForSeconds(0.050F); //Wait for cooldown
        ShipFire = true; //Enable firing again

    }
//Boss Firing Side Cannons
    private void FixedUpdate()
    {
        if (ShipFire == true) //Check if ship can fire
        {
            StartCoroutine(CallFiring());
        }
    }
}
