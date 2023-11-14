using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5.0f;
    private bool movingRight = true;
    private float moveRange = 2.0f;
    private float leftBoundary;
    private float rightBoundary;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 배경의 좌우 경계값 계산
        SpriteRenderer backgroundRenderer = GameObject.Find("NewBackground").GetComponent<SpriteRenderer>();
        Vector3 backgroundSize = backgroundRenderer.bounds.size;
        leftBoundary = backgroundRenderer.transform.position.x - backgroundSize.x / 2f;
        rightBoundary = backgroundRenderer.transform.position.x + backgroundSize.x / 2f;
    }

    void Update()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (transform.position.x >= rightBoundary - moveRange)
                movingRight = false;
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (transform.position.x <= leftBoundary + moveRange)
                movingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree"))
        {
            movingRight = !movingRight; // 이동 방향을 반대로 변경
            moveSpeed = 8.0f;
        }
    }
}
