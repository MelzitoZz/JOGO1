using UnityEngine;

public class Personagem : MonoBehaviour
{
    [Header("Movimentacao")]
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("Pulo Multiplo")]
    public int quantidadeDePulosExtra = 2;
    private int pulosRestantes;

    [Header("Verificacao de chao")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private Rigidbody2D rb;
    private float moveInput;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pulosRestantes = quantidadeDePulosExtra;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput != 0)
        {
            Flip(moveInput);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            pulosRestantes = quantidadeDePulosExtra;
        }

        if (Input.GetButtonDown("Jump") && pulosRestantes > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            pulosRestantes--;
            animator.SetTrigger("Pulo");
        }

        animator.SetFloat("Velocidade", Mathf.Abs(moveInput));
        animator.SetBool("NoChao", isGrounded);
        animator.SetFloat("VelocidadeY", rb.linearVelocity.y);
    }

    void Flip(float direcao)
    {
        transform.localScale = new Vector3(Mathf.Sign(direcao), 1f, 1f);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "espinho")
        {
            ControledeGame.instance.MostarGameOver();
            Destroy(gameObject);
        }
    }
}