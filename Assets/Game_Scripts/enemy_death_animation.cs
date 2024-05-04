using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_death_animation : MonoBehaviour
{

    private Animator enemy_animator;
    private BoxCollider2D enemy_collider;
    private Rigidbody2D rigidbody2D;

    [SerializeField] private LayerMask Player;

    [SerializeField] private AudioSource enemy_death_sound;

    private void Start()
    {
        enemy_animator = GetComponent<Animator>();
        enemy_collider = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Physics2D.BoxCast(enemy_collider.bounds.center, enemy_collider.bounds.size, 0f, Vector2.up, .1f, Player))
        {
            enemy_death_sound.Play();
            enemy_animator.SetInteger("death", 1);
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            enemy_collider.enabled = false;

            //destroying movement script
            Destroy(this.GetComponent("Enemy_Patrol"));

            destroy_enemy();
        }
    }

    private void destroy_enemy()
    {
        Destroy(this.gameObject,0.6f);
    }


}
