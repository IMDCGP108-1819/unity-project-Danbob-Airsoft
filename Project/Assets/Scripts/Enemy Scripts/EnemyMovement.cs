using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Spawn at random set spawnpoint


    //Random Movement
    public float AccelerationTime;
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float CharacterVelocity = 20f;
    private Vector2 MovementDirection;
    private Vector2 MovementPerSecond;
    public GameObject Planet;

    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {

        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        MovementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        MovementPerSecond = MovementDirection * CharacterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (MovementPerSecond.x * Time.deltaTime),
        transform.position.y + (MovementPerSecond.y * Time.deltaTime));

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "World")
        {
            calcuateNewMovementVector();
        }

        if (collision.gameObject.tag == "Outer Barrier")
        {
            MovementDirection = -MovementDirection;
            MovementPerSecond = MovementDirection * CharacterVelocity;
            StartCoroutine(WallBounce());
        }
    }
    private IEnumerator WallBounce()
    {
        yield return new WaitForSeconds(2);
        calcuateNewMovementVector();
    }
}