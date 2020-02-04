using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailSpawner : MonoBehaviour
{
    public GameObject trail;
    public float spawnRate = .3f;
    public float spawnTimer = 0;
    public float startDelay = .1f;

    void Start()
    {
        spawnTimer = spawnRate - startDelay;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;




        if (spawnTimer >= spawnRate)
        {
           Spawn();
        }


    }


    void Spawn()
    {
        var newTrail = Instantiate(trail);
        newTrail.transform.position = transform.position;
        spawnTimer = 0;
    }
}
