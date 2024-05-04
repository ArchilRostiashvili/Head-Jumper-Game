using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem_Collect : MonoBehaviour
{

    private int gems;

    [SerializeField] private Text gems_count;

    [SerializeField] private AudioSource gems_collect_sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gems_collect_sound.Play();
        Destroy(collision.gameObject);
        gems++;
        gems_count.text = "Gems: " + gems;
    }

}
