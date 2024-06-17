using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]
    private Text pickUpText;

    private bool pickUpAllowed;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        // Tìm PlayerInventory trên đối tượng người chơi và tăng số lượng chìa khóa
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.AddKey();
            audioManager.PlayVFX(audioManager.key);
        }

        // Ẩn thông báo nhặt chìa khóa
        pickUpText.gameObject.SetActive(false);

        // Hủy đối tượng chìa khóa
        Destroy(gameObject);
    }
}
