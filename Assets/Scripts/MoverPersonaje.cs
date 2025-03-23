using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    private float velocidadX = 5.0f;
    private float velocidadY = 5.0f;
    private Rigidbody2D rb;
    private bool Saltando;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Movimiento con Translate
        float movHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * movHorizontal * Time.deltaTime * velocidadX);

        float movVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * movVertical * Time.deltaTime * velocidadY);
    }

    void Update()
    {
        // Detectar si el personaje puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && Saltando)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7.0f); // Aplicar impulso de salto
            Saltando = false; // Evitar saltos en el aire
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Saltando = true;
        }
    }
}
