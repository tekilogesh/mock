using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFflow : MonoBehaviour
{
    public bool playerBodyInside;

    public float pushForce;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        if(playerBodyInside)
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerBodyInside = true;
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * pushForce);
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerBodyInside = false;
            collision.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
