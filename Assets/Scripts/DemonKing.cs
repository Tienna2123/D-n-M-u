using System.Collections;
using UnityEngine;

public class DemonKing : MonoBehaviour
{
    AudioManager audioManager;
    public Transform player;
    public float chaseDistance; // Khoảng cách bắt đầu đuổi
    public float attackDistance; // Khoảng cách bắt đầu tấn công
    public float speed = 2f;

    private Animator animator;
    private Vector3 startPosition;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        startPosition = transform.position;

    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < attackDistance)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer < chaseDistance)
        {
            ChasePlayer();
        }
        else
        {
            ReturnToStart();
        }
    }

    void AttackPlayer()
    {
        animator.SetTrigger("Cleave");
        
    }

    void playSoundCleave()
    {
        audioManager.PlayVFX(audioManager.cleave);
    }
    void playSoundWalk()
    {
        audioManager.PlayVFX(audioManager.walk);
    }






    void ChasePlayer()
    {
        animator.SetBool("Walk", true);
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Flip hướng mặt nếu cần
        
    }

    void ReturnToStart()
    {
        float distanceToStart = Vector3.Distance(transform.position, startPosition);

        if (distanceToStart > 0.1f)
        {
            animator.SetBool("Walk", true);
            Vector3 direction = (startPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Flip hướng mặt nếu cần
            
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    
}
