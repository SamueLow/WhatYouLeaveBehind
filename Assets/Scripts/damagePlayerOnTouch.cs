using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayerOnTouch : MonoBehaviour
{
    private int damage = 1;
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Player") && spriteRenderer.color.a > .5f) 
        {
            playerController.instance.damagePlayer(damage);
        }
    }
}
