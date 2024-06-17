using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Đã thoát Game!");
    }
    
}
