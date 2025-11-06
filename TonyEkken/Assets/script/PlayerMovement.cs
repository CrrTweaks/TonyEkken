using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float moveInput;
    private bool isCrouched = false;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput > 0) 
        {
            // Muovi a destra
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {
            // Muovi a sinistra
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

        // Controllo per accovacciarsi
        if (Input.GetKey(KeyCode.LeftControl) && isCrouched == false)
        {
            isCrouched = true;
            spriteRenderer.color = Color.purple;
        
        }
        else
        {
            isCrouched = false;
            spriteRenderer.color = Color.red;
        }       

         if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Previene doppi salti
        } 
    }

    // Funzione chiamata automaticamente quando il collider tocca un altro collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    //Rilevare quando lascia il terreno
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}