using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow cameraInstance;
    [Tooltip("a float value to lerp the position of camera to target")]
    public float lerpTime;

    [Tooltip("target of the camera")]
    public Transform target;

    [SerializeField] float yOffset=2;
    float z;

    [Header("bool to stop cameraMovements")]
    public bool canMove = true;
    [Header("bool to use camera dissolve")]
    public bool playerIsDead;
    private void Awake()
    {
        if (cameraInstance == null)
        {
            cameraInstance = this;
        }
        else
        {
            Destroy(this);
            Debug.Log("two camera scripts");
        }
    }
    void Start()
    {
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && GameManager.gmInstance.playerControls!=null)
            target = GameManager.gmInstance.playerControls.transform;
    }
    private void FixedUpdate()
    {


        if (canMove)
        {
            if (target != null)
            {
                
                Vector3 requiredPosition = new Vector3(target.position.x, target.position.y + yOffset, z);
                transform.position = Vector3.Lerp(transform.position, requiredPosition, lerpTime * Time.deltaTime);
            }
        }
    }

    public void nulltarget()
    {
        target = null;
    }

    void dipToBlack()
    {
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, 0, 0.2f);
    }
}
