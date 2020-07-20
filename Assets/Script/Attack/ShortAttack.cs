using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortAttack : Attack
{
    private void Start()
    {
        StartCoroutine(TimeDestroy());
    }

    IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
