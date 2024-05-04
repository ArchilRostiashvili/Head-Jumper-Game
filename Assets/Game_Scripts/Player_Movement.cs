using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    //Collider object
    private BoxCollider2D playerCollider;

    private Rigidbody2D rb;

    //jump speed and walk speed
    [SerializeField] private float movement_speed;
    [SerializeField] private float jump_speed;

    //The terrain 
    [SerializeField] private LayerMask terrain;

    //enum of move set
    private enum MVset {idle, running, jumping, falling };

    //player sprite renderer
    private SpriteRenderer playerSpriteRenderer;

    //player animator
    private Animator player_animator;

    [SerializeField] private AudioSource jump_sound;

    void Start()
    {
        //Getting player's collider
        playerCollider = GetComponent<BoxCollider2D>();

        rb = GetComponent<Rigidbody2D>();

        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        player_animator = GetComponent<Animator>();
    }

    void Update()
    {
        //getting movement direction
        float dirX = Input.GetAxisRaw("Horizontal");

        //setting player movement according to direction
        rb.velocity = new Vector2(movement_speed * dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && player_on_ground())
        {
            jump_sound.Play();
            rb.velocity = new Vector3(rb.velocity.x, jump_speed, 0);
        }

        check_player_mv_state(dirX);
        
    }

    private void check_player_mv_state(float directionX)
    {
        MVset mvState;

        if(directionX > 0f)
        {
            mvState = MVset.running;
            playerSpriteRenderer.flipX = false;
        } else if(directionX < 0f)
        {
            mvState = MVset.running;
            playerSpriteRenderer.flipX = true;
        } else { mvState = MVset.idle;}

        if(rb.velocity.y > .1f)
        {
            mvState = MVset.jumping;
        } else if (rb.velocity.y < -.1f) {
            mvState = MVset.falling;
        }

        player_animator.SetInteger("mvState", (int)mvState);
    }

    //Check player's collision with terrain
    private bool player_on_ground()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, terrain);
    } 

}
