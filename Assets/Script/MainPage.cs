using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//시작화면
public class MainPage : MonoBehaviour
{
    
    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
