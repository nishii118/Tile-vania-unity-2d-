using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody2D rigidbody2D;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        bulletSpeed = 10f;
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        // Debug.Log("l")
    }

    void Update()
    {
        Shoot();
        FlipSprite();
    }

    void FlipSprite()
    {
        if (xSpeed < Mathf.Epsilon)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    void Shoot()
    {
        rigidbody2D.velocity = new Vector2(xSpeed, 0);

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
