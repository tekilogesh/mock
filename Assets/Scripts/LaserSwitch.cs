using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public float lazerDistance;

    public LineRenderer lineR;

    public bool lineClosed;

    [SerializeField] Animator animator;

    public LayerMask notSelf;
    void Start()
    {
        lineR = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        animator.SetBool("open", !lineClosed);
        lineR.SetPosition(0, transform.position);
        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, transform.right, lazerDistance,notSelf);
        if (hit2d)
        {
            lineR.SetPosition(1, hit2d.point);
            if (hit2d.collider.CompareTag("switch"))
            {
                lineClosed = true;
            }
            else
            {
                lineClosed = false;
            }

        }
        else
        {
            lineR.SetPosition(1, transform.position + transform.right * lazerDistance);
        }
    }
}
