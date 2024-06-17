using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Vector2 checkPointPos;
    Rigidbody2D playerRb;
    AudioManager audioManager;

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public GameObject gameOverObject;
    private bool dead;


    void Start()
    {
        checkPointPos = transform.position;
    }


    private void Awake()
    {
        currentHealth = startingHealth;
        playerRb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {

        }
        else
        {
            if (!dead)
            {

                dead = true;
                
                gameOverObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }


    public void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            TakeDamage(1);
        }
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }
    public void Die()
    {
        audioManager.PlayVFX(audioManager.death);
        Respawn();
    }
    void Respawn()
    {
        transform.position = checkPointPos;
    }

}
