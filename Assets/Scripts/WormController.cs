using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public Vector3 holeEndScale;
    public Vector3 wormEndPos;
    public Vector3 wormStartPos;
    public GameObject worm;
    public float speed = .05f;
    public bool hidden = true;
    public float hideDistance = 5f;
    private float currentHealth = 13f;







    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerController.instance.transform.position) < hideDistance && hidden)
        {
            hidden = false;
            StartCoroutine(PopOut());
        }
    }

    void AttackPlayer()
    {
        Instantiate(Resources.Load("Prefabs/MouthTarget") as GameObject);
    
    }
    IEnumerator PopOut()  //kind of works like an update function, runs over multiple frame
    {
        Collider2D child = gameObject.GetComponentInChildren<BoxCollider2D>();
        child.GetComponent<BoxCollider2D> ().enabled = false;
        GetComponent<CapsuleCollider2D> ().enabled = false;
        worm.SetActive(false);
        transform.localScale = Vector3.zero;
        while(transform.localScale.x < holeEndScale.x)
        {
            transform.localScale += new Vector3(speed, speed, speed);
            yield return new WaitForEndOfFrame();
        }

        worm.transform.position = wormStartPos;
        worm.SetActive(true);
        while(worm.transform.position.y < wormEndPos.y)
        {
            worm.transform.position += new Vector3(0, speed, 0);
            yield return new WaitForEndOfFrame();
        }
        child.GetComponent<BoxCollider2D> ().enabled = true;
        GetComponent<CapsuleCollider2D> ().enabled = true;
        InvokeRepeating("AttackPlayer", 0, 5f);
    }

    public void takeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
