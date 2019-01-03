using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject ShipToSpawn;
    public float spawnTime = 3f;   // How long between each spawn.
    public Transform[] spawnPoints;   // An array of the spawn points this enemy can spawn from.
    public int EnemyNumber; //Maximum number of enemies in the game
    List<GameObject> Enemy;

    void Start()
    {
        Enemy = new List<GameObject>();
        for (int i = 0; i < EnemyNumber; i++) //For every 1 in the max number of enemies, spawn an enemy
        {
            GameObject obj = Instantiate(ShipToSpawn);
            Enemy.Add(obj); //Add spawned ship to active ships
        }
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    { 
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (!Enemy[i].activeInHierarchy) //Finds inactive enemies
            {
                // Find a random index between zero and one less than the number of spawn points.
                int spawnPointIndex = Random.Range(0, spawnPoints.Length); //Gets a random spawn point
                Enemy[i].transform.position = spawnPoints[spawnPointIndex].position; //Moves inactive enemy to spawn point
                Enemy[i].transform.rotation = spawnPoints[spawnPointIndex].rotation;
                Enemy[i].SetActive(true); //Respawns enemy
                Enemy[i].GetComponent<EnemyMovement>().Inside = false; //Allows enemy to enter the playable area
            }
        }
    }
}
