using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    public float distance;
    public float speedEnemy;
    private Animator enemyAnim;
    private float distanceSqr;
    private Vector3 startPosition;
    private bool isReturning;

    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        enemyAnim = GetComponent<Animator>();
        distanceSqr = distance * distance; // Tính giá trị bình phương của distance
        startPosition = transform.position;
        isReturning = false;
    }

    void Update()
    {
        // Tính toán khoảng cách bình phương giữa player và bat
        float currentDistanceSqr = (playerPos.position - transform.position).sqrMagnitude;

        if (currentDistanceSqr < distanceSqr)
        {
            // Nếu trong khoảng cách, di chuyển về phía player và bật hoạt ảnh Fly
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speedEnemy * Time.deltaTime);
            enemyAnim.SetBool("Fly", true);
            isReturning = false; // Đặt lại trạng thái quay về
        }
        else
        {
            // Nếu ngoài khoảng cách
            if (!isReturning)
            {
                // Bắt đầu di chuyển về vị trí ban đầu
                transform.position = Vector2.MoveTowards(transform.position, startPosition, speedEnemy * Time.deltaTime);
                enemyAnim.SetBool("Fly", true);

                // Kiểm tra nếu đã về được vị trí ban đầu
                if (Vector2.Distance(transform.position, startPosition) < 0.1f)
                {
                    isReturning = true;
                }
            }
            else
            {
                // Đang quay trở về vị trí ban đầu, chuyển sang hoạt ảnh Idle
                enemyAnim.SetBool("Fly", false);
            }
        }
    }
}
