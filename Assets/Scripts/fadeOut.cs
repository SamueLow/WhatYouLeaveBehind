using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour
{
    
    public SpriteRenderer spriteRenderer;
    private float lifeTime = 1f;
    public float timeForFade = 1f;

    void Start()
    {
        lifeTime = timeForFade;
    }
    void FixedUpdate()
    {
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }

        else
        {
            lifeTime -= Time.deltaTime;
            var alpha = 1 - lifeTime/timeForFade;
            spriteRenderer.color = Color.Lerp(Color.white, new Color(1,1,1,0), alpha);
        }
    }
}
