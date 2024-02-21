using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
     public float jumpForce;
    private bool isJumping;
    private bool isGrounded;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Animator animator;
    private bool anim_spawn = true;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public SpriteRenderer spriteRenderer;
    void Update()
    {
        if (!anim_spawn && Input.GetButtonDown("Jump") && isGrounded) // si la spacebar est pressé et qu'on est au sol alors l'état de l'objet passe a "est en train de sauter"
        {
            isJumping = true;
        }
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        
       
        MovePlayer(horizontalMovement);
        
       
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        
    }
    void MovePlayer(float _horizontalMovement)
    {
        if (!anim_spawn)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Anim_spawn_end()
    {
        Debug.Log("fin");
        anim_spawn = false;
    }
}
