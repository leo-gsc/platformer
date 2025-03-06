using UnityEngine;

public class MortJoueur : MonoBehaviour
{
    private Transform spawnPoint; // Point de spawn du joueur

    void Start()
    {
        // Trouver l'objet avec le tag "SpawnPoint" dans la scène
        GameObject sp = GameObject.FindGameObjectWithTag("SpawnPoint");
        
        if (sp != null)
        {
            spawnPoint = sp.transform;
        }
        else
        {
            Debug.LogError("Aucun objet avec le tag 'SpawnPoint' trouvé dans la scène !");
        }
    }

    void detruireballe (){
        
            GameObject[] balles = GameObject.FindGameObjectsWithTag("balle"); // Récupère toutes les balles

            foreach (GameObject balle in balles)
            {
                Destroy(balle); // Détruit chaque balle
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("danger"))
        {
            if (spawnPoint != null)
            {
                transform.position = spawnPoint.position; // Déplace le joueur au spawn
            }
            else
            {
                Debug.LogError("Le spawnPoint n'est pas défini !");
            }
            detruireballe();
            
        }
        else if (other.CompareTag("checkpoint"))
        {
            spawnPoint = other.transform; // Met à jour le point de spawn
        }
        else if (other.CompareTag("balle"))
        {
            transform.position = spawnPoint.position; // Déplace le joueur au spawn
            detruireballe();
                }
            }
}
