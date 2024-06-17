using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tìm PlayerInventory trên đối tượng người chơi và tăng số lượng coin
            PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddCoin();
                audioManager.PlayVFX(audioManager.coin);

            }

            // Hủy đối tượng coin
            Destroy(gameObject);
        }
    }
}