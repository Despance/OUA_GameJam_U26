using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("debug");

     /* if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("2");
        }*/
    }
}
