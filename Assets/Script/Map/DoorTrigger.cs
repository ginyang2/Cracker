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
            if (!mapevent.clear && !mapevent.close)
                mapevent.CloseDoor(collision.gameObject.GetComponent<Player>(),gameObject.name);
        }
    }
}
