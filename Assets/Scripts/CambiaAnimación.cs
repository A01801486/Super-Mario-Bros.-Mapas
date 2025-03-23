using UnityEngine;

public class CambiaAnimacion : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Asignar la velocidad horizontal
        animator.SetFloat("velocidad", Mathf.Abs(Input.GetAxis("Horizontal")));

        // Detectar si el personaje está en el aire
        bool estaSaltando = Mathf.Abs(rb.linearVelocity.y) > 0.1f;
        animator.SetBool("estaSaltando", estaSaltando);
    }
}
