using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobshootpredefine : MonoBehaviour
{
    public GameObject projectilePrefab; // Le projectile à tirer
    public Transform firePoint; // Point de spawn du projectile
    public float fireRate = 1f; // Temps entre chaque tir
    public float projectileSpeed = 5f; // Vitesse du projectile

    private Transform player;
    private float nextFireTime;
    

    // Update is called once per frame
    void Update()
    {
        // Tirer à intervalle régulier
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
    }

    void Shoot()
{
    // Liste des angles où le mob va tirer
    float[] angles = new float[] { 180f, 135f, 90f, 45f, 0f }; // 180° = gauche, 0° = droite

    foreach (float angle in angles)
    {
        // Convertir l'angle en direction (vecteur)
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        // Créer une rotation correspondant à l'angle
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // Instancier le projectile avec la bonne rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction.normalized * projectileSpeed; // Appliquer la direction et la vitesse
        }
    }
}

}
