using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrap : MonoBehaviour
{
    public float tocDoXoay = 5f;
    public float tocDoDiChuyen;
    public Transform diemA;
    public Transform diemB;
    private Vector3 diemMucTieu;

    private void Start()
    {
        diemMucTieu = diemA.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, diemMucTieu, tocDoDiChuyen * Time.deltaTime);
        if(Vector3.Distance(transform.position, diemMucTieu) < 0.1f)
        {
            if(diemMucTieu == diemA.position)
            {
                diemMucTieu = diemB.position;
            }
            else
            {
                diemMucTieu = diemA.position;
            }
        }
        
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, tocDoXoay);
    }
}
