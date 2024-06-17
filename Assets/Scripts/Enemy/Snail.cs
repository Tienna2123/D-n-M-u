using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float moveSpeed = 5f;

    bool facingRight = true;

    Vector3 pos, localScale;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWhereToFace();

        if (facingRight)
            MoveRight();
        else
            MoveLeft();
    }

    void CheckWhereToFace()
    {
        if (pos.x < 1f)
            facingRight = true;

        else if (pos.x > 7f)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos;
    }

}
