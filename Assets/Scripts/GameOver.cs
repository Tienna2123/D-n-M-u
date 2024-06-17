using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f; // Đảm bảo game không bị tạm dừng
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load lại cảnh hiện tại
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Đã thoát Game!");
    }
}
