using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Player movement speed.")]
    public float moveSpeed;
    [Header("Player jump force.")]
    public float jumpForce;

    [Header("bool to check Whether player touching ground or not.")]
    public bool isGrounded;

    [Header("Player's Rigidbody component")]
    public Rigidbody2D rb;

    [Header("to neglectPlayer")]
    public LayerMask notPlayer;
    public float range;

    public LayerMask GrabLayer;

    [Header("Bool to check player is dead or not")]
    public bool isDead;

    [Header("Bool to lockPlayer movements")]
    public bool canMove = true;

    [Header("legPostion")]
    public Transform legpostion;

    public float radius;

    public bool facingRight;
    void Start()
    {
        if(!rb)
        rb = GetComponent<Rigidbody2D>();

       if(GameManager.gmInstance.playerControls == null || GameManager.gmInstance.playerControls!=this)
        {
            GameManager.gmInstance.playerControls = this;
        }
        else
        {
            Debug.Log("gameManager already has a player");
        }
        facingRight = true;
    }

   
    void Update()
    {
        if (isGrounded && Input.GetKeyDown(InputManager.inputInstance.jumpKey))
        {
            jump(new Vector2(InputManager.inputInstance.moveX, 1).normalized, jumpForce);
        }

        //if(Input.GetKeyDown(KeyCode.P))
        //{
        //    isDead = true;
        //    destroyThis();
        //}
        if(isDead)
        {
            destroyThis();
        }

        flipPlayer();
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (canMove)
            {
                movePlayer(Vector2.right, moveSpeed);
                isGrounded = Physics2D.OverlapCircle(legpostion.position, radius, notPlayer);
            }
        }
    }

    void flipPlayer()
    {
        if (InputManager.inputInstance.moveX > 0 && !facingRight)
        {
            facingRight = true;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            Debug.Log("facingRight");
        }
        else if (InputManager.inputInstance.moveX < 0 && facingRight)
        {
            facingRight = false;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            Debug.Log("facingLeft");
        }
    }

    void movePlayer(Vector2 direction, float _moveSpeed)
    {
        rb.AddForce(direction * InputManager.inputInstance.moveX * _moveSpeed * Time.deltaTime);
    }

    void jump(Vector2 direction, float _jumpForce)
    {
        rb.AddForce(direction * _jumpForce,ForceMode2D.Impulse);
    }

    void destroyThis()
    {
        GameManager.gmInstance.playerSpawned = false;
        CameraFollow.cameraInstance.nulltarget();
        rb.freezeRotation = false;
        gameObject.layer = LayerMask.NameToLayer("Grablayer");
        Destroy(GetComponent<playerGrab>());
        Destroy(GetComponent<PlayerLadder>());
        Destroy(this);
        GetComponent<SpriteRenderer>().color = Color.magenta;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hazards"))
        {
            isDead = true;
            if(GameManager.gmInstance.playerCount==0)
            {
                GameManager.gmInstance.setLevelTimer();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(legpostion.position, radius);
    }
}
