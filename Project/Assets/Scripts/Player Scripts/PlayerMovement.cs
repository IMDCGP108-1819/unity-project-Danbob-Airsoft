using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float rotatespeed;
    public GameObject MoveHelp;
    private Vector2 MoveDirection;
    private Vector3 TempMove;
    private PlayerShooting ShootScript;
    public float LaserSpeed;
    private bool CanFire = true;
    public float FireDelay;
    public Vector3 PlayerRotation;
    public Rigidbody2D rigidBody;
    public AudioSource AudioSource;
    public AudioClip LaserClip;

    void Start()
    {
        ShootScript = gameObject.GetComponentInChildren<PlayerShooting>();
        AudioSource.clip = LaserClip;
    }

    void FixedUpdate()
    {
        //Gets inputs from arrow keys and sets to variables for rotation or movement
        float moveVector = Input.GetAxis("Vertical");
        float rotateVector = Input.GetAxis("Horizontal");
        //Find the vector between the MoveHelp object (Attached to the prefab) and the prefab itself
        TempMove = MoveHelp.transform.position - this.transform.position;
        //Debug.Log(TempMove);

        //Creating a movement Vector2 to account for player rotation
        MoveDirection = new Vector2(TempMove.x, TempMove.y);

        //Applying force to the MoveDirection and applying move speed
        rigidBody.AddForce(MoveDirection * moveVector * movespeed);

        //Attempted movement code (Would only move the player sideways)
        //this.transform.Translate(moveVector * movespeed * Time.deltaTime, 0f, 0f);

        //On Horizontal input rotates the prefab with rotation speed
        this.transform.Rotate(0f, 0f, -rotateVector * rotatespeed * Time.deltaTime);
        PlayerRotation = this.transform.rotation.eulerAngles;

        //If Space Pressed- Shoot
        if (Input.GetAxisRaw("Fire1") == 1 && CanFire)
        {
            StartCoroutine(FireLaser());
        }
    }
    //Prevnting Constant firing
    private IEnumerator FireLaser()
    {
        //Runs then disables till first run and delay are complete
        CanFire = false;
        //Runs Shooting script
        ShootScript.Firing(LaserSpeed, MoveDirection, PlayerRotation);
        //Play sounds
        AudioSource.Play();
        //Waits
        yield return new WaitForSeconds(FireDelay);
        //Enables firing
        CanFire = true;
    }
        
}
