using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public GameObject[] hitboxes;
    private float timeBTWAttacks;
    private float timeSinceLastAttack = 0;
    public int meleeDamage = 2;
    

    
    public enum Direction {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    void Start()
    {
        // toggleHitbox(false, Direction.Up);
        TurnOffHitboxes();

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastAttack += Time.deltaTime;   
        if (timeSinceLastAttack >= timeBTWAttacks)
        {
            TurnOffHitboxes();
        }

    }

    public void ToggleHitbox(bool turnOn, Direction direction)
    {
        hitboxes[(int)direction].SetActive(turnOn);
    }

    public void Attack(Direction direction, float hitTime)
    {
        timeBTWAttacks = hitTime;
        TurnOffHitboxes();

        ToggleHitbox(true, direction);
        timeSinceLastAttack = 0;
    }

    public void TurnOffHitboxes()
    {
         for (int dir = 0; dir < 4; dir++)
        {
            ToggleHitbox(false, (Direction) dir);
        }
    }
}
