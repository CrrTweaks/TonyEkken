using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocita = 5f;      // velocità orizzontale
    public float forzaSalto = 7f;    // forza del salto
    public float durataSalto = 0.3f;   // durata del salto in secondi

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = false;
    private float jumpTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimento orizzontale
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;

        rb.linearVelocity = new Vector2(moveInput * velocita, rb.linearVelocity.y);

        // Inizio salto con Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpTimer = durataSalto;
            isGrounded = false;
        }
        // Durante il salto
        if (jumpTimer > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forzaSalto);
            jumpTimer -= Time.deltaTime;
        }

        // abbasso
        if (Input.GetKey(KeyCode.C))
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpTimer = 0f;
        }
    }
}