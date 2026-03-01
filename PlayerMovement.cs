using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;     // Velocidad de caminar
    public float runSpeed = 8f;      // Velocidad de correr
    public float jumpForce = 10f;    // Fuerza del salto

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isRunning;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // --- Movimiento horizontal ---
        float moveInput = Input.GetAxis("Horizontal");

        // Shift para correr
        isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);

        // --- Girar el personaje según dirección ---
        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

        // --- Saltar ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }

        // --- Actualizar animaciones ---
        float absSpeed = Mathf.Abs(moveInput);

        if (!isGrounded)
        {
            // Saltando
            animator.Play("Player_Jump");
        }
        else if (absSpeed > 0.1f)
        {
            if (isRunning)
                animator.Play("Player_Run");
            else
                animator.Play("Player_Walk");
        }
        else
        {
            // Quieto
            animator.Play("Player_Idle");
        }
    }

    // Detectar el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }
}
