using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float speed = 5f;      // Vitesse de déplacement
    public float jumpForce = 10f; // Force du saut
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Si pas de Rigidbody2D, on l'ajoute automatiquement
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // Déplacement gauche/droite
        float move = Input.GetAxis("Horizontal"); 
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Saut (uniquement si le cercle est au sol)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

    }
} 