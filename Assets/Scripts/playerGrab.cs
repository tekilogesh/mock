using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGrab : MonoBehaviour
{
    public bool canGrabPlayerBody;

    public bool isHoldingPlayerBody;

    public float grabDistance;

    public LayerMask layerTograb;

    GameObject temp;

    public Transform holdPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canGrabPlayerBody = Physics2D.Raycast(transform.position, transform.right, grabDistance, layerTograb);
        if (Input.GetKeyDown(InputManager.inputInstance.grabKey) && canGrabPlayerBody && !isHoldingPlayerBody)
        {
            Grab();
        }
        else if (Input.GetKeyDown(InputManager.inputInstance.throwkey) && isHoldingPlayerBody)
        {
            drop();
        }

        void Grab()
        {

            temp = deadPlayer();
            Destroy(temp.GetComponent<Rigidbody2D>());
           // temp.gameObject.transform.parent = transform;
            isHoldingPlayerBody = true;

        }
        void drop()
        {
            temp.AddComponent<Rigidbody2D>();
           // temp.gameObject.transform.parent = null;
            isHoldingPlayerBody = false;
            temp = null;
        }

        if (isHoldingPlayerBody) 
        {
            temp.transform.position = holdPosition.position;
        }

        GameObject deadPlayer()
        {
            RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position, transform.right, grabDistance, layerTograb);

            if (hit2D[0].collider.CompareTag("Player"))
            {
                return hit2D[0].collider.gameObject;
            }
            else
            {
                return null;
            }
        }
    }
}
