using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float climbSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Vector2 moveInput;
    Rigidbody2D rigidbody2D;
    Animator animator;
    CapsuleCollider2D capsuleCollider2D;
    BoxCollider2D boxCollider2D;
    float gravityScaleAtStart;
    bool isAlive;
    GameSession gameSession;
    // void Awake() {
    //     gameSession = FindObjectOfType<GameSession>();

    // }
    void Start()
    {
        isAlive = true;
        runSpeed = 4f;
        jumpSpeed = 7.5f;
        climbSpeed = 4f;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        // rigidbody2D.gravityScale = 20;
        gravityScaleAtStart = rigidbody2D.gravityScale;
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        if (!isAlive) return;
        Run();
        FlipSprite();
        ClimbLadder();
        Die();

    }

    void OnFire(InputValue inputValue) {
        if (!isAlive) return;
        Instantiate(bullet, gun.position, transform.rotation);
    }
    void OnMove(InputValue inputValue)
    {
        if (!isAlive) return;
        moveInput = inputValue.Get<Vector2>();
        // Debug.Log(moveInput);
    }

    void OnJump(InputValue inputValue)
    {
        if(!isAlive) return;
        if (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (inputValue.isPressed)
            {
                rigidbody2D.velocity += new Vector2(0f, jumpSpeed);
            }
        }

    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHasHorizontalSpeed);
        // if (moveInput.x != 0) {
        //     animator.SetBool("isRunning", true);
        // } else {
        //     animator.SetBool("isRunning", false);
        // }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed == true)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);

        }
    }
    void ClimbLadder()
    {
        if (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder")) == false)
        {
            rigidbody2D.gravityScale = gravityScaleAtStart;
            animator.SetBool("isClimbing", false);
            return;
        }
        // else { Debug.Log("touching ladder"); }
        // rigidbody2D.gravityScale = 1;
        rigidbody2D.gravityScale = 0f;

        Debug.Log("climbing");
        Vector2 climbVelocity = new Vector2(rigidbody2D.velocity.x, moveInput.y * climbSpeed);
        rigidbody2D.velocity = climbVelocity;

        bool playerHasVerticalSpeed = Mathf.Abs(rigidbody2D.velocity.y) > Mathf.Epsilon;
        if (playerHasVerticalSpeed) { animator.SetBool("isClimbing", playerHasVerticalSpeed); }

    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     // if (other.gameObject.layer == "Enemies") {
    //     //     isAlive = false;
    //     // }
    //     if (other.)
    // }

    void Die() {
        if (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazard"))) {
            isAlive = false;
            rigidbody2D.velocity = new Vector2(0, jumpSpeed);
            animator.SetTrigger("Dying");
            // FindObjectOfType<GameSession>().ProcessPlayerDeath();
            // i dont know why this line code work
            // solution is that gameObject still not be destroyed, you have to set active to false to get the other game session to call method 
            gameSession.ProcessPlayerDeath();
        }
    }
}

