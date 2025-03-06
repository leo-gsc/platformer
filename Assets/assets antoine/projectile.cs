using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5f; // Temps avant destruction
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // Détruire après un certain temps
    }
    void Update()
    {
        if (rb != null)
        {
            // Calculer l'angle de rotation basé sur la direction de la vitesse
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle); // Appliquer la rotation en 2D
        }
    }
}
