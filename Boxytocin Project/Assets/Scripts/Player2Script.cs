using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public int maxHealth = 100;
    public float respawnDelay = 5.0f;
    public Transform respawnPoint2;
    public int currentHealth;
    private Vector2 movement;
    private Vector3 lastDir;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private bool cannotMove;
    public HealthBar healthbar;
    public Transform weapon;
    public static bool alive;
    public static int player2Score;
    Animator anim;
    public float dashDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused && !CountdownHandler.gameOver)
        {

            if (alive)
            {

                movement.x = Input.GetAxisRaw("Horizontal2");
                movement.y = Input.GetAxisRaw("Vertical2");
                cannotMove = CheckCollisions(box, movement, 0.05f);

                if (currentHealth <= 0)
                {
                    alive = false;
                    Player1Script.player1Score++;
                    StartCoroutine("Respawn");
                }

                if (Input.GetKeyDown(KeyCode.M))
                {
                    handleDash();
                }

                //Movement Animations
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
                {

                    anim.SetBool("Up", true);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", true);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", true);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", true);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", true);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", true);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", true);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", true);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {

                    anim.SetBool("Up", true);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", true);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", true);
                    lastDir = (Vector3)movement;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {

                    anim.SetBool("Up", false);
                    anim.SetBool("UpLeft", false);
                    anim.SetBool("Down", false);
                    anim.SetBool("DownLeft", false);
                    anim.SetBool("UpRight", false);
                    anim.SetBool("Left", true);
                    anim.SetBool("DownRight", false);
                    anim.SetBool("Right", false);
                    lastDir = (Vector3)movement;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (cannotMove)
        {
            movement.x = 0;
            movement.y = 0;
        }
        else
        {

            if (movement.x != 0 && movement.y != 0)
            {
                rb.MovePosition(rb.position + movement * (moveSpeed * 0.7f) * Time.fixedDeltaTime);
            }
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        }
    }

    private bool CheckCollisions(Collider2D moveCollider, Vector2 direction, float distance)
    {
        if (moveCollider != null)
        {
            RaycastHit2D[] hits = new RaycastHit2D[10];
            ContactFilter2D filter = new ContactFilter2D() { };

            int numHits = moveCollider.Cast(direction, filter, hits, distance);
            for (int i = 0; i < numHits; i++)
            {
                if (!hits[i].collider.isTrigger)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    IEnumerator Respawn()
    {
        movement.x = 0;
        movement.y = 0;
        yield return new WaitForSeconds(respawnDelay);
        gameObject.transform.position = respawnPoint2.position;
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
        alive = true;
    }

    private void handleDash()
    {
        transform.position += lastDir * dashDistance;
    }

}
