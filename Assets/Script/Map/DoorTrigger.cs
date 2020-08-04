using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어가문을 통과했는지 판단한다.
public class DoorTrigger : MonoBehaviour
{
    public MapEvent mapevent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어 접촉");
            if (!mapevent.clear && !mapevent.close)
                mapevent.CloseDoor();
        }
    }
}
