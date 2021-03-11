using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : MonoBehaviour
{
    [Header("animator of the door")]
    public Animator animator;// creating a refernce for the animator.

    [Header("bool to check whether the player pressed the switch")]
    public bool pressed;// this bool is check whether the player pressed the switch.

    void Start()
    {
        
    }

    
    void Update()
    {// setting the animator bool value.
        animator.SetBool("open", pressed);
    }
    // checking the collision between player and this gameobject.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pressed = false;
        }
    }
}
