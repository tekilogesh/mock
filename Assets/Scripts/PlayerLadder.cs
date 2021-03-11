using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadder : MonoBehaviour
{
    public bool playerIsUsingLadder;

    [SerializeField]  float currentGravity;

    public float ladderSpeed;

    void Start()
    {
        currentGravity = GetComponent<Rigidbody2D>().gravityScale;
    }

    void Update()
    {
        if(playerIsUsingLadder)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,0);

            transform.Translate(Vector3.up * InputManager.inputInstance.moveY * Time.deltaTime *ladderSpeed);     
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = currentGravity;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ladder"))
        {
            playerIsUsingLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            playerIsUsingLadder = false;
        }
    }
}
