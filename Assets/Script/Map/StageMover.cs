using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GameManager.Instance.ChangeNextStage();
            Debug.Log("NextStage");
        }
    }
}
