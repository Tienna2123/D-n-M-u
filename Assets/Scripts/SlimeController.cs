using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private Rigidbody2D rb;
    private Transform target;

    public float moveSpeed = 2f;
    private float timeToReachTarget = 1f; // Thời gian dự kiến để đến target
    private float timeSinceLastTargetUpdate = 0f; // Thời gian kể từ lần cập nhật target cuối cùng

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = pointB; // Bắt đầu từ điểm B
        timeSinceLastTargetUpdate = timeToReachTarget; // Khởi tạo để cập nhật target ngay lập tức
    }

    private void Update()
    {
        // Cập nhật thời gian
        timeSinceLastTargetUpdate += Time.deltaTime;

        // Di chuyển tới điểm tiếp theo dựa trên vị trí hiện tại và khoảng cách
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        // Kiểm tra nếu đã đến gần điểm target và đủ thời gian đã trôi qua
        if (Vector3.Distance(transform.position, target.position) < 0.1f && timeSinceLastTargetUpdate >= timeToReachTarget)
        {
            // Đặt lại vận tốc về 0 để tránh di chuyển thêm
            rb.velocity = Vector2.zero;

            // Chuyển đổi điểm đích
            target = target == pointB ? pointA : pointB;
            Flip();

            // Đặt lại bộ đếm thời gian
            timeSinceLastTargetUpdate = 0f;
        }
    }

    private void Flip()
    {
        // Lật hướng của slime
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pointA.position, 0.5f);
            Gizmos.DrawWireSphere(pointB.position, 0.5f);
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}
