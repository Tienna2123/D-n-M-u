using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 100;
    public EnemyHealthBar HealthBar;
    
    void Start()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
        
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
