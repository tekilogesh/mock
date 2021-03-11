using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public int buildIndex=1;

   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.CompareTag("Player"))
        {
            GameManager.gmInstance.gameWon = true;
        }
    }
}
