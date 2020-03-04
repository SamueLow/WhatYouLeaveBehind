using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerController : MonoBehaviour
{

    public Rigidbody2D rb2D;
    private float speed = 2.5f;
    public Sprite[] idleSprites;//0 - down, 1- up, 2- left, 3- right
    public SpriteRenderer playerRenderer;
    private float maxHealth = 100;
    public float currentHealth;
    public static playerController instance;//static means there is only one of it
    private HitboxController attackController;
    private HitboxController.Direction direction;
    private float attackLength = .05f;
    public GameObject damageIcon;
    public float damageIconSpawnDistance = .7f;

    
    private void Awake() 
    {
        instance = this;//"this" is a keyword to reference the current script

        Application.targetFrameRate = 60;
        currentHealth = maxHealth;
    }

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        attackController = gameObject.GetComponent<HitboxController>();
        HUDDisplay.instance.updateHPBar(currentHealth, maxHealth);
        
    }


    
    void GetInput()
    {
        var newPosition = rb2D.position;
        var currentDirection = direction;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += speed * Time.deltaTime* Vector2.up;
            direction = HitboxController.Direction.Up;

        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += speed * Time.deltaTime* Vector2.down;
            direction = HitboxController.Direction.Down;           
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += speed * Time.deltaTime* Vector2.left;
            direction = HitboxController.Direction.Left;           
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += speed * Time.deltaTime* Vector2.right;
            direction = HitboxController.Direction.Right;         
        }

        if(currentDirection != direction)
        {
            attackController.TurnOffHitboxes();
        }

        playerRenderer.sprite = idleSprites[(int)direction];

        if (Input.GetKey(KeyCode.Space))
        {
            attackController.Attack(direction, attackLength);
        }
        
        rb2D.MovePosition(newPosition);
            
    }
    void FixedUpdate()
    {
        GetInput();
        checkPlayerHealth();
    }

    void checkPlayerHealth()
    {
        if ( currentHealth <= 0)
            SceneManager.LoadScene(1);
    }

    public void damagePlayer(float damageAmount)
    {
        currentHealth -= damageAmount;
        HUDDisplay.instance.updateHPBar(currentHealth, maxHealth);
        HUDDisplay.instance.playerTookDamage();
        GameObject newDamageIcon = Instantiate(damageIcon);
        newDamageIcon.transform.parent = transform;// makes the damage Icon parented to the player so that it moves with it
        Vector2 direction = newDamageIcon.GetComponent<damageIconController>().direction;
        newDamageIcon.transform.position = transform.position + ((Vector3)direction)*damageIconSpawnDistance;
    }




}
