using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{

    private BoxCollider2D playerCollider;

    [SerializeField] private LayerMask Enemy;

    private Rigidbody2D rb;
    private Animator player_animator;

    [SerializeField] private AudioSource player_death_sound;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();

        rb = GetComponent<Rigidbody2D>();

        player_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (enemy_demaged_player())
        {
            player_death_sound.Play();
            player_animator.SetInteger("mvState", 4);
            rb.bodyType = RigidbodyType2D.Static;
            Debug.Log("-1 Health");
            Invoke("ReloadLevel", 0.04f);
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool enemy_demaged_player()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.left, .1f, Enemy) 
            && Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.right, .1f, Enemy) 
            && Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.up, .1f, Enemy);
    }

}
