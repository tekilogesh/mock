using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //this is ti use singleton method.
    public static InputManager inputInstance;

    private void Awake()
    {
        if (inputInstance == null) 
        {
            inputInstance = this;
        }
        else
        {
            Destroy(this);
            
        }
    }
    // this is to set input for different actions.
    public KeyCode pauseGameKey;
    public KeyCode jumpKey;
    public KeyCode interactKey;
    public KeyCode grabKey;
    public KeyCode throwkey;

    
    //these float variables are to use the input axes.
    public float moveX;
    public float moveY;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }
}
