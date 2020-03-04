using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public Vector3 direction;
    private float speed = 7f;
    private float damage = .1f;
    public GameObject shooter;

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {

       // this doesn't work for some reason, but it does in on trigger
        if(other.gameObject == shooter || other.gameObject.CompareTag("playerProjectile"))
        {
            
            return;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.gameObject == shooter || other.gameObject.CompareTag("playerProjectile"))
        {
            return;
        }

        if(other.gameObject.CompareTag("Enemy")) 
        {
            other.gameObject.GetComponent<enemyController>().takeDamage(damage);
        }

        if(other.gameObject.CompareTag("worm")) 
        {
            other.gameObject.GetComponent<WormController>().takeDamage(damage);
        }

        if(other.gameObject.CompareTag("EnemyProjectile") ) 
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
