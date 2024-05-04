using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour
{

    [SerializeField] private Transform Player;

    private void Update()
    {
        //unity gets that transform is of camera itself
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}
