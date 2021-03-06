﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Setting variables needed for movement
    public float AccelerationTime;
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float CharacterVelocity = 15f;
    private Vector2 MovementDirection;
    private Vector2 MovementPerSecond;
    public bool Inside = false; //Allows enemies to enter the field

    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector(); //Calls the function to find a new movement direction
        Inside = true; //The first wave begins inside the area
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
        if (collision.gameObject.tag == "Inside Checker") //If the enemy hits the invisible barrier around the inside layer then they are counted as inside
        {
            Inside = true;
        }
        //On collisions with world objects and the inner barier only if the enemy is counted as inside then change direction
        if (collision.gameObject.tag == "World" || collision.gameObject.tag == "Outer Barrier" || collision.gameObject.tag == "CapitalShip" || collision.gameObject.tag == "Inner Barrier" && Inside == true)
        {
            MovementDirection = -MovementDirection;
            MovementPerSecond = MovementDirection * CharacterVelocity;
            StartCoroutine(WallBounce());
        }
    }
    //Wait for 2 seconds then find a new random direction
    private IEnumerator WallBounce()
    {
        yield return new WaitForSeconds(2);
        calcuateNewMovementVector();
    }
}