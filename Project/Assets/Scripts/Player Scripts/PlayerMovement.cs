using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float rotatespeed;
    public GameObject MoveHelp;
    private Vector2 MoveDirection;
    private Vector3 TempMove;

    public Rigidbody2D rigidBody;

    void FixedUpdate()
    {
        float moveVector = Input.GetAxis("Vertical");
        float rotateVector = Input.GetAxis("Horizontal");

        TempMove = MoveHelp.transform.position - this.transform.position;
        Debug.Log(TempMove);

        MoveDirection = new Vector2(TempMove.x, TempMove.y);

        rigidBody.AddForce(MoveDirection * moveVector * movespeed);
        //this.transform.Translate(moveVector * movespeed * Time.deltaTime, 0f, 0f);
        this.transform.Rotate(0f, 0f, -rotateVector * rotatespeed  * Time.deltaTime);
    }
}
