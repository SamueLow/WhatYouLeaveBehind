using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageIconController : MonoBehaviour
{
    private float speed = .02f;
    public Vector2 direction;
    

    void Awake()
    {
        direction = Random.insideUnitCircle;

    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * direction.x, transform.position.y + speed * direction.y, transform.position.z);
    }
}
