using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//방에서 일어나는 이벤트 관할
public class MapEvent : MonoBehaviour
{
    public GameObject door;
    public List<GameObject> enemys;
    public bool clear = false;
    public bool close = false;
    private int maxEnemy;
    public Transform[] tpPosition;
    private void Start()
    {
        maxEnemy = enemys.Count;
        OpenDoor();
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].SetActive(false);
        }
    }

    public void CloseDoor(Player player, string touchedPosition)
    {
        switch (touchedPosition)
        {
            case "Up":
                player.TP(tpPosition[0].position);
                break;
            case "Down":
                player.TP(tpPosition[1].position);
                break;
            case "Left":
                player.TP(tpPosition[2].position);
                break;
            case "Right":
                player.TP(tpPosition[3].position);
                break;
        }
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == null)
            {
                enemys.RemoveAt(i);
                Debug.Log(enemys);
            }
            enemys[i].SetActive(true);
        }
        door.SetActive(true);
        close = true;
        GameManager.Instance.mapEvent = this;
        GameManager.Instance.enemyNum = enemys.Count;
        GameManager.Instance.inRoom = true;
    }

    public void OpenDoor()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == null)
            {
                enemys.RemoveAt(i);
            }
        }
        door.SetActive(false);
    }
}
