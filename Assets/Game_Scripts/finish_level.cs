using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_level : MonoBehaviour
{

    [SerializeField] private GameObject finish;

    private void Update()
    {
        if (Vector2.Distance(finish.transform.position, transform.position) < .1f)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            SceneManager.LoadScene(0);
        }
    }

}
