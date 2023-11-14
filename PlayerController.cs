  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    SpriteRenderer backgroundRenderer;
    float xBoundary;
    float yBoundary;

    float jumpForce = 500.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    int coin = 0;
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        backgroundRenderer = GameObject.Find("NewBackground").GetComponent<SpriteRenderer>();

        Vector3 backgroundSize = backgroundRenderer.bounds.size;
        xBoundary = backgroundSize.x;
        yBoundary = backgroundSize.y;
    }

    void Update()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -xBoundary, xBoundary);
        float clampedY = Mathf.Clamp(transform.position.y, -yBoundary, yBoundary);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid2D.AddForce(transform.up * jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            key = 1;

        float speedX = Mathf.Abs(rigid2D.velocity.x);
        if (speedX < maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        animator.speed = speedX / 2.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("coin"))
        {
            coin = coin + 1;
            Debug.Log(coin);
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("star") && coin == 10)
        {
            Debug.Log("finish");
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Clear");
        }

        else if (collision.CompareTag("monster") || collision.CompareTag("arrow"))
        {
            Debug.Log("Watch out!");
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
        }
    }
}
