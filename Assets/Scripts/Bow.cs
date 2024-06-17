using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    private Animator playerAnimator; // Biến Animator của Player
    public float shootDoneDelay = 0.5f; // Thời gian chờ trước khi kích hoạt ShootDone

    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        // Tìm và gán Animator của Player
        playerAnimator = GetComponentInParent<Animator>();
        if (playerAnimator == null)
        {
            Debug.LogError("No Animator component found on the parent of " + gameObject.name);
        }
    }

    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (playerAnimator != null && playerAnimator.runtimeAnimatorController != null)
        {
            audioManager.PlayVFX(audioManager.humanattack);
            playerAnimator.SetTrigger("Shoot"); // Kích hoạt trigger cho hoạt ảnh tấn công
            StartCoroutine(ShootDoneCoroutine());
        }
        else
        {
            Debug.LogError("Animator or AnimatorController is missing on " + playerAnimator.gameObject.name);
        }
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

        Destroy(newArrow, 2f); // Xóa mũi tên sau 2 giây
    }

    private IEnumerator ShootDoneCoroutine()
    {
        yield return new WaitForSeconds(shootDoneDelay);
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("ShootDone"); // Kích hoạt trigger cho hoàn tất bắn
        }
    }
}
