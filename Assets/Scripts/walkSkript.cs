using UnityEngine;
using UnityEngine.InputSystem;

public class walkSkript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    private Vector2 lastMoveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed)
            {
                moveInput.y += 1f;
            }
            if (Keyboard.current.sKey.isPressed)
            {
                moveInput.y -= 1f;
            }
            if (Keyboard.current.aKey.isPressed)
            {
                moveInput.x -= 1f;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                moveInput.x += 1f;
            }
        }

        if (moveInput.magnitude > 1f)
        {
            moveInput.Normalize();
        }

        rb.linearVelocity = moveInput * speed;

        if (moveInput.sqrMagnitude > 0.001f)
        {
            lastMoveInput = moveInput.normalized;
        }

        if (animator == null && rb != null)
        {
            animator = GetComponent<Animator>();
        }

        if (animator != null)
        {
            animator.SetFloat("MoveX", lastMoveInput.x);
            animator.SetFloat("MoveY", lastMoveInput.y);
            animator.SetBool("IsMoving", moveInput.sqrMagnitude > 0.001f);
        }
    }
}