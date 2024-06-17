using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    AudioManager audioManager;

    public Text checkPointText;
    Health health;
    public Transform respawnPoint;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    
    private void Start()
    {
        checkPointText.gameObject.SetActive(false);
    }

    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health.UpdateCheckPoint(respawnPoint.position);
            audioManager.PlayVFX(audioManager.checkpoint);
            spriteRenderer.sprite = active;


        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            checkPointText.gameObject.SetActive(true);

        }
        
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkPointText.gameObject.SetActive(false);



        }
    }
}
