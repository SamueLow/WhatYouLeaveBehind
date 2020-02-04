using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float yBound;
    public float xBound;
    public float zDistance;
    public float cameraSpeed;
    public Transform playerTransform;

    void Start()
    {
        
    }

    void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        float minX = gameObject.transform.position.x - xBound;
        float maxX = gameObject.transform.position.x + xBound;
        float minY = gameObject.transform.position.y - yBound;
        float maxY = gameObject.transform.position.y + yBound;



        Vector3 newPosition = gameObject.transform.position;

        if (playerTransform.position.x < minX)
        {
            newPosition.x = playerTransform.position.x + xBound;
        }

        else if (playerTransform.position.x > maxX)
        {
            newPosition.x = playerTransform.position.x - xBound;
        }
        
        if (playerTransform.position.y < minY)
        {
            newPosition.y = playerTransform.position.y + yBound;
        }
        else if (playerTransform.position.y > maxY)
        {
            newPosition.y = playerTransform.position.y - yBound;
        }
        newPosition.z = zDistance;
        gameObject.transform.position = newPosition;
    }
}
