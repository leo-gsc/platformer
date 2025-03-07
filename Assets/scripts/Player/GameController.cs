using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{

    private Animator anim;
    private bool dead;
    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;
    Rigidbody2D playerRb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        checkpointPos = transform.position;
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    void Die()
    {
        anim.SetTrigger("die");
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;
        StartCoroutine(Respawn(0.5f));
    
    }

    IEnumerator Respawn(float duration)
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(duration);
        GetComponent<PlayerMovement>().enabled = true;
        dead = false;
        anim.SetTrigger("IDLE");
        transform.position = checkpointPos;
        spriteRenderer.color = Color.white;

    }
}