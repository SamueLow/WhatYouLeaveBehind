using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    private int damage = 2;
    public GameObject shooter;

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject == shooter)
            return;

        if(other.gameObject.CompareTag("Player") ) 
        {
            playerController.instance.damagePlayer(damage);
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
