using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMover : MonoBehaviour
{
    private bool loading;
    private void Start()
    {
        loading = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player") && !loading)
        {
            loading = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("NextStage");
        }
    }
}
