using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    Rigidbody2D rb;
    private bool daRoi = false;
    public Transform diemKhoiPhuc;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !daRoi)
        {
            rb.isKinematic = false;
            daRoi = true;
            Invoke("KhoiPhuc", 2f);
        }
    
    }

    private void KhoiPhuc()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = diemKhoiPhuc.position;
        daRoi = false;
    }
    
}
