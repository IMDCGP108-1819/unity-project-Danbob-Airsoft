using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public GameObject Laser;
    private GameObject LaserInstance;

    public void Firing(float LaserSpeed, Vector2 MoveDirection,Vector3 PlayerRotation)
    {
        //Create Laser
        LaserInstance = Instantiate(Laser, this.transform.position, Quaternion.identity);

        //Rotate Laser
        PlayerRotation = new Vector3(PlayerRotation.x, PlayerRotation.y, PlayerRotation.z - 90f);
        LaserInstance.transform.Rotate(PlayerRotation);

        //Move Laser
        Rigidbody2D LaserInstanceBody = LaserInstance.gameObject.GetComponent<Rigidbody2D>();
        LaserInstanceBody.AddForce(MoveDirection * LaserSpeed);
    }
}
