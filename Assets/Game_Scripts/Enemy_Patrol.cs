using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private SpriteRenderer enemy_sprite;

    private void Start()
    {
        enemy_sprite = GetComponent<SpriteRenderer>();
        enemy_sprite.flipX = true;
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 1f)
        {
            enemy_sprite.flipX = false;
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length) { currentWaypointIndex = 0; enemy_sprite.flipX = true;}
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

    }

}

