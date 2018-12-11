using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalShipSpawn : MonoBehaviour
{
    public GameObject CapitalShip;

    float next_spawn_time;

    void Start()
    {
        //start off with next spawn time being 'in 5 seconds'
        next_spawn_time = Time.time + 60.0f;
    }

    void Update()
    {
        if (Time.time > next_spawn_time)
        {
            //Spawn Capital Ship
            Instantiate(CapitalShip, this.transform.position, this.transform.rotation);
            //increment next_spawn_time
            next_spawn_time += 60.0f;
        }
    }
}
