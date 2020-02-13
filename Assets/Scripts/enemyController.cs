using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyController : MonoBehaviour
{
    public float speed;
    public float minRange;
    public float maxRange;
    public Seeker seeker;
    public Path path;
    public int waypoint;
    public float nextWaypointDistance;
    public bool finishedPath;
    public float repathRate = .5f;
    private float lastRepath = float.NegativeInfinity;
    private float timeBTWShots = 1.5f;
    private float timeSinceLastShot = 0;


    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerController.instance.transform.position);
        if (path != null && ( distanceToPlayer > minRange && distanceToPlayer < maxRange))
            MoveAlongPath();
        if (Time.time > lastRepath + repathRate && seeker.IsDone())
        {
            lastRepath = Time.time;
            seeker.StartPath(transform.position, playerController.instance.gameObject.transform.position, OnPathComplete);
        }

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= timeBTWShots)
        {
            Shoot();
            timeSinceLastShot = 0;
        }

    }

    void Shoot()
    {
        var fireballPrefab = Resources.Load("Prefabs/fireball") as GameObject;
        var instantiatedFireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        var newDirection = playerController.instance.gameObject.transform.position - transform.position;

        instantiatedFireball.GetComponent<fireballController>().setDirection(newDirection.normalized);
        instantiatedFireball.GetComponent<fireballController>().shooter = gameObject;
    }



    void MoveAlongPath()
    {
        finishedPath = false;
        float distanceToWaypoint;
        while (true)
        {
            distanceToWaypoint = Vector2.Distance(transform.position, path.vectorPath[waypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                if (waypoint + 1 < path.vectorPath.Count)
                {
                    waypoint++;
                }
                else 
                {
                    finishedPath = true;
                    break;
                }
            }

            else
            {
                break;
            }

        }

        transform.position += speed * Time.deltaTime * (path.vectorPath[waypoint] - transform.position).normalized;

    }

    // void MoveTowardsPlayer()
    // {

    //     Vector3 playerPosition = player.transform.position;
    //     Vector3 enemyPosition = transform.position; // dont need gameobject.... bc it defaults to what its attached to
    //     Vector3 vectorToPlayer =  playerPosition - enemyPosition;

    //     if (vectorToPlayer.magnitude > minRange && vectorToPlayer.magnitude < maxRange)
    //         transform.position += speed * Time.deltaTime * vectorToPlayer.normalized; //normalized makes the vector length 1 in same dir

    // }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            waypoint = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hitbox"))
            Destroy(gameObject);
    }
}
