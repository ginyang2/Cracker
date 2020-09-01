using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Tilemaps;
//플레이어가 던전에 입장할 때 던전을 생성할 때 사용된다.
public class LevelManager : MonoBehaviour
{
    public List<Grid> maps;
    public Grid startMap;
    public Grid endMap;
    public int vertical;
    public int horizontal;
    public int size;
    public Grid Wall;
    public Transform startPoint;
    // Start is called before the first frame update
    public void MakeLevel()
    {
        MakeRoom();
        MakeSide();
    }

    private void MakeRoom()
    {
        for(int i = 0; i < vertical; i++)
        {
            for(int ii = 0; ii < horizontal; ii++)
            {
                if (i == 0 && ii == 0)
                {
                    Instantiate(startMap, new Vector3(i * size, ii * size, 1), Quaternion.identity, this.transform);
                }
                else if (i == vertical -1 && ii == horizontal -1)
                {
                    Instantiate(endMap, new Vector3(i * size, ii * size, 1), Quaternion.identity, this.transform);
                }
                else { 
                    Instantiate(maps[Random.Range(0, maps.Count)], new Vector3(i * size, ii * size,1),Quaternion.identity, this.transform);
                }
;            }

        }
        
    }

    private void MakeSide()// 통로를 막는 벽 생성
    {
        for (int i = 0; i < vertical; i++)//위 아래 벽
        {
            Instantiate(Wall, new Vector3(i * size, -8, 1), Quaternion.identity, this.transform);
            Instantiate(Wall, new Vector3(i * size, horizontal * size - 12, 1), Quaternion.identity, this.transform);
        }
        for (int i = 0; i < horizontal; i++)//오른쪽 왼쪽 벽
        {
            Instantiate(Wall, new Vector3(-8, i * size, 1), Quaternion.identity, this.transform);
            Instantiate(Wall, new Vector3(vertical * size - 12, i * size, 1), Quaternion.identity, this.transform);
        }
    }

    public void RemoveAllMap()
    {
        Transform[] childList = GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }
    }
}