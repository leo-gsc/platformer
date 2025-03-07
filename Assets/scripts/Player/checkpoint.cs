using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
   // Controller gameController;
    // Start is called before the first frame update
    private void Awake()
    {
      //  gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
         //   gameController.UpdateCheckpoint(transform.position);
        }
    }
}
