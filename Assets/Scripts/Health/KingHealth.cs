using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingHealth : MonoBehaviour
{
    AudioManager audioManager;

    public float Hitpoints;
    public float MaxHitpoints = 100;
    public EnemyHealthBar HealthBar;

    private Animator animator; // Thêm biến Animator
    private bool isDead = false; // Để tránh kích hoạt nhiều lần

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    void Start()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);
        animator = GetComponent<Animator>(); // Khởi tạo Animator
    }

    public void TakeHit(float damage)
    {
        if (isDead) return; // Nếu đã chết, không thực hiện thêm

        Hitpoints -= damage;
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);

        
        animator.SetTrigger("TakeHit"); // Kích hoạt hoạt ảnh TakeHit
        audioManager.PlayVFX(audioManager.hit);

        if (Hitpoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true; // Đánh dấu đã chết
        audioManager.PlayVFX(audioManager.kingdeath);
        animator.SetTrigger("Death"); // Kích hoạt hoạt ảnh Death
        // Có thể thêm logic để vô hiệu hóa các hành động khác của boss ở đây
        Destroy(gameObject, 3f); // Hủy gameObject sau 2 giây để cho phép hoàn thành hoạt ảnh
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            Arrow arrow = collision.GetComponent<Arrow>();
            if (arrow != null)
            {
                TakeHit(arrow.damage);
                Destroy(collision.gameObject); // Hủy mũi tên sau khi va chạm
            }
        }
    }
    
}
