using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingRockController : MonoBehaviour
{
    private float followTime = 1.2f;
    private float detatchTime = .3f;
    private float rockFalltime = .4f;
    public GameObject rock;
    private bool damagingPlayer = false;
    private int damage = 1;


    IEnumerator Start()
    {
        rock.SetActive(false);
        float timer = 0;
        while (timer <= followTime)
        {
            timer += Time.deltaTime;
            followPlayer();
            yield return new WaitForEndOfFrame();
        }
        timer = 0;

        while (timer <= detatchTime)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        timer = 0;
        rock.SetActive(true);
        Vector3 rockStartPos =  rock.transform.position;
        while ( timer <= rockFalltime)
        {
            timer += Time.deltaTime;
            rock.transform.position = Vector3.Lerp(rockStartPos, transform.position, timer/rockFalltime);
            yield return new WaitForEndOfFrame();
        }
        damagingPlayer = true;

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
   
    }

    void followPlayer()
    {
        transform.position = playerController.instance.transform.position;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        Debug.Log(damagingPlayer);
        if (other.gameObject.CompareTag("Player") && damagingPlayer)
        {
            playerController.instance.damagePlayer(damage);

        }
    }


}
