using UnityEngine;

public class bossAttacks : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private bool canSpawn = false;
    private GameObject player;



    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        GameObject player = GameObject.FindWithTag("Player");
    }


    private void UpdateMovement()
    {
        if (player.transform.position.x < transform.position.x)
        {
            Debug.Log("Le joueur est à gauche du boss.");
        }
        if (movingLeft)
        {
            if (transform.position.x <= leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }
        
    }

    private void SwordAttack()
    {

    }

    private void MagicAttack()
    {
    }
}
