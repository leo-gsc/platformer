using UnityEngine;

public class MobShooter2D : MonoBehaviour
{
    public GameObject projectilePrefab; // Le projectile à tirer
    public Transform firePoint; // Point de spawn du projectile
    public float fireRate = 1f; // Temps entre chaque tir
    public float projectileSpeed = 5f; // Vitesse du projectile

    private Transform player;
    private float nextFireTime;


    void Update()
    {
        player = GameObject.FindGameObjectWithTag("player").transform; // Trouve le joueur
        if (player != null)
        {
            // Regarder vers le joueur
            Vector2 direction = (player.position - transform.position).normalized;

            // Tirer à intervalle régulier
            if (Time.time >= nextFireTime)
            {
                Shoot(direction);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * projectileSpeed;
        }
    }
}
