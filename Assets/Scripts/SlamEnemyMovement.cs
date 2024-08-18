using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamEnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        moveSpeed = 2.5f;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemySprite();
    }

    void FlipEnemySprite()
    {
        transform.localScale = new Vector2(-Mathf.Sign(rigidbody2D.velocity.x), 1f);
    }
}
