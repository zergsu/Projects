using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Add this component to a GameObject to allow control of it via keyboard.
The Horizontal axis controlls will move the player left and right.
Pressing the space bar will cause the character to jump, but only if the character is in contact with a gameObject tagged with "Floor"
*/
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    public float movementSpeed = 5f;
    public float jumpForce = 500f;
    float xAxisInput = 0;

    public SoundManagerScript SoundManager;
    Vector2 spawn;

    Animator camAnimator;
    Animator animator;

    public bool died = false;

    public GameObject Shadow;
    public bool respawned = false;
    
    public Dialog playerDialog;

    Rigidbody2D rb;
    BoxCollider2D Collider;


    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, 0.05f, layer);

        return raycastHit2D.collider != null;
    }
    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        SoundManager.PlaySound("jump");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camAnimator = GameObject.Find("Main Camera").GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spawn = transform.position;
    }


    private void Rotate() //takes character scale and change the face into the direction
    {
        Vector3 CharacterScale = transform.localScale;
        if (xAxisInput > 0)
        {
            CharacterScale.x = 1f;
        }
        else if (xAxisInput < 0)
        {
            CharacterScale.x = -1f;
        }
        transform.localScale = CharacterScale;
    }

    private void Update()
    {
        xAxisInput = Input.GetAxis("Horizontal");
        if (playerDialog.inDialog == false)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                if (IsGrounded())
                {
                    Shadow.SetActive(false);
                    animator.SetTrigger("Jump");
                    animator.SetBool("isJumping", true);
                    Jump();
                }
            }
            Rotate();
        }

        if(IsGrounded())
        {
            Shadow.SetActive(true);
        }
        else if(IsGrounded()==false)
        {
            Shadow.SetActive(false);
        }

        animator.SetFloat("velocityY", rb.velocity.y);

        if (IsGrounded() && rb.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
        }
    }
    void FixedUpdate()
    {
        if (playerDialog.inDialog == false)
        {
            if (xAxisInput == 0)
            {
                animator.SetBool("isRunning", false);
            }
            else
            {
                animator.SetBool("isRunning", true);
            }
            rb.velocity = new Vector2(movementSpeed * xAxisInput, rb.velocity.y);
        }

        if (playerDialog.inDialog == true)//freeze player when he is in dialog
        {
            rb.velocity -= rb.velocity;
            animator.SetBool("isRunning", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            died = true;
            Respawn();
            SoundManager.PlaySound("damage");
        }
    }


    public void Respawn()
    {
        transform.position = spawn;
        respawned = true;
    }
}
