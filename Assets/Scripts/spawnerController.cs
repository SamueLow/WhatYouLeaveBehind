using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 3f;
    public float health = 1f;
    public float spawnTimer = 0;
    public float minDistToPlayer = 5f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        var distToPlayer = Vector3.Distance(playerController.instance.transform.position, transform.position);



        if (spawnTimer >= spawnRate && distToPlayer < minDistToPlayer)
        {
           Spawn();
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hitbox"))
            Destroy(gameObject);
    }

    void Spawn()
    {
        var newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = transform.position;
        spawnTimer = 0;
    }
}
