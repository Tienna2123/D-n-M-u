using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private Text Text; // Thông báo hướng dẫn người chơi

    [SerializeField]
    private Text gateText; // Thông báo cho việc qua cổng

    

    private bool canPass;
    private PlayerInventory playerInventory;

    
    // Use this for initialization
    private void Start()
    {
        Text.gameObject.SetActive(false);
        gateText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (canPass && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null && playerInventory.keyCount >= 3)
            {
                
                LoadNextLevel();
            }
            else
            {
                ShowNotEnoughKeysMessage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInventory = collision.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                Text.gameObject.SetActive(true); // Hiển thị thông báo hướng dẫn
                gateText.gameObject.SetActive(true);
                gateText.text = "Nhấn E để qua màn";
                canPass = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Text.gameObject.SetActive(false); // Ẩn thông báo hướng dẫn
            gateText.gameObject.SetActive(false);
            canPass = false;
            playerInventory = null;
        }
    }

    private void ShowNotEnoughKeysMessage()
    {
        gateText.text = "Bạn cần 3 chìa khoá để qua";
        StartCoroutine(HideMessageAfterDelay(2f));
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (playerInventory == null || playerInventory.keyCount >= 3)
        {
            gateText.text = "Nhấn E để qua màn";
        }
        else
        {
            gateText.gameObject.SetActive(false);
        }
    }

    private void LoadNextLevel()
    {
        // Tải màn chơi mới
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}