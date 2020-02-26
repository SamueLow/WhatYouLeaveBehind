using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public Vector3 direction;
    private float speed = 7f;
    private int damage = 1;
    public GameObject shooter;

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
               Debug.Log("pizza");
       
        if(other.gameObject == shooter)
                   return;



        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("pizza");

        if(other.gameObject.CompareTag("Enemy")) 
        {
            other.gameObject.GetComponent<enemyController>().takeDamage(damage);
        }

        if(other.gameObject.CompareTag("enemyProjectile") ) 
        {
            Destroy(other.gameObject);
        }

        if(other.gameObject == shooter)
            return;

        if(other.gameObject.CompareTag("Spawner")) 
        {
            other.gameObject.GetComponent<spawnerController>().takeDamage(damage);
        }

    
        Destroy(gameObject);
    }

    public void setDirection(Vector3 directionIn)
    {
        direction = directionIn;

        float zRotation = Vector3.Angle(Vector3.left, directionIn);
        if (directionIn.y > 0)
            zRotation = -zRotation;
        transform.rotation = Quaternion.Euler(0,0, zRotation);
    }
}
