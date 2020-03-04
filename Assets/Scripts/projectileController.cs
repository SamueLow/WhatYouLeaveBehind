using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    public float timeBTWShots = .0001f;
    public float timeSinceLastShot = 0;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) //0 is left, 1 is right, 2 is scroll wheel
        {
            if (timeSinceLastShot >= timeBTWShots)
            {
                Shoot();
                timeSinceLastShot = 0;
            }
        }

        timeSinceLastShot += Time.deltaTime;
    }

    void Shoot()
    {
        //gettting location of cursor
        var screenPosition = Input.mousePosition;
        var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0;

        var bulletPrefab = Resources.Load("Prefabs/greenBeam") as GameObject;
        var instantiatedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        var newDirection = worldPosition - playerController.instance.gameObject.transform.position ;

        instantiatedBullet.GetComponent<bulletController>().setDirection(newDirection.normalized);
        instantiatedBullet.GetComponent<bulletController>().shooter = gameObject;
    }
}
