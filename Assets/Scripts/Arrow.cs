using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (hasHit == false)
        {
            // Xoay mũi tên theo hướng di chuyển
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb != null)
        {
            hasHit = true;
            rb.velocity = Vector2.zero; // Dừng mũi tên lại khi va chạm
            rb.isKinematic = true; // Đặt Rigidbody2D thành kinematic
            
        }
    }
}