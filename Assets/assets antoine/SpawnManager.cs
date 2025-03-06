using UnityEngine;
using Cinemachine; // 🔥 Ajoute cette ligne pour éviter l'erreur

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab; // Le prefab du personnage
    public Transform spawnPoint;    // Le point de spawn

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);

        // 🔥 Trouver la caméra Cinemachine et l'attacher au joueur
        CinemachineVirtualCamera cam = GameObject.Find("camerajoueur").GetComponent<CinemachineVirtualCamera>();
        if (cam != null)
        {
            cam.Follow = player.transform;
        }
        else
        {
            Debug.LogError("Cinemachine Virtual Camera 'camerajoueur' introuvable !");
        }
    }
    
}
