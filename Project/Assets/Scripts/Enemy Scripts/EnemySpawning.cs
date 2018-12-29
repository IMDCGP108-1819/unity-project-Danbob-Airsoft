using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject ShipToSpawn;
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int EnemyNumber;
    List<GameObject> Enemy;

    void Start()
    {
        Enemy = new List<GameObject>();
        for (int i = 0; i < EnemyNumber; i++)
        {
            GameObject obj = Instantiate(ShipToSpawn);
            Enemy.Add(obj);
        }
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    { 
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (!Enemy[i].activeInHierarchy)
            {
                // Find a random index between zero and one less than the number of spawn points.
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                Enemy[i].transform.position = spawnPoints[spawnPointIndex].position;
                Enemy[i].transform.rotation = spawnPoints[spawnPointIndex].rotation;
                Enemy[i].SetActive(true);
                Enemy[i].GetComponent<EnemyMovement>().Inside = false;
            }
        }
    }
}
