using UnityEngine;
using GameConstants;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool isDoubleJump = true;

    private Rigidbody2D rigidbody2d;
    private Animator animator;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            animator.SetBool("walk", false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rigidbody2d.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                isDoubleJump = true;
                animator.SetBool("jump", true);
            }
            else
            {
                if (isDoubleJump)
                {
                    rigidbody2d.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    isDoubleJump = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.GROUND_LAYER)
        {
            isJumping = false;
            animator.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.GROUND_LAYER)
        {
            isJumping = false;
        }
    }
}
