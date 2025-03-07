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
    private bool spawnTriggered = false;
    private bool swordAttack = false;
    private bool magicAttack = false;
    private Transform playerTransform;
    private Animator anim;



    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    void Update()
    {
        UpdateMovement();
    }
    private void UpdateMovement()
    {
        if (playerTransform != null && !spawnTriggered)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer <= 9f)
            {
                anim.SetTrigger("boss_spawn");
                spawnTriggered = true;
            }
        }

        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                if (playerTransform != null && playerTransform.position.x > transform.position.x)
                {
                    magicAttack = true;
                    MagicAttack();
                }
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                if (playerTransform != null && playerTransform.position.x - transform.position.x <= 2)
                {
                    swordAttack = true;
                    SwordAttack();
                }
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    private void SwordAttack()
    {
        anim.SetTrigger("swordAttack");
        swordAttack = false;
    }

    private void MagicAttack()
    {
        anim.SetTrigger("magicAttack");
        magicAttack = false;
    }
}
