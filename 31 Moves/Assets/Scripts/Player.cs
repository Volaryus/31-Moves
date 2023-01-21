using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveX = 1f;
    [SerializeField]
    int moveAmount = 31;
    int currentMove;
    [SerializeField]
    float jumpForce = 4f;

    [SerializeField]
    LayerMask groundLayer;
    Collider2D collider;
    Rigidbody2D rb;

    bool moveLeft = false;
    bool moveRight = false;
    bool canJump = true;

    float startX;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        currentMove = moveAmount;
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            Debug.Log("Moving Left");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startX - moveX, transform.position.y, transform.position.z), 0.04f);
            if (transform.position.x <= startX - moveX)
            {
                moveLeft = false;
            }
        }
        if (moveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startX + moveX, transform.position.y, transform.position.z), 0.04f);
            if (transform.position.x >= startX + moveX)
            {
                moveRight = false;
            }
        }
    }

    public void MoveRight()
    {
        //transform.position += new Vector3(moveX, 0, 0);
        if (currentMove < 1)
        {
            //Activate retry button(Death screen)
            return;
        }
        currentMove--;
        moveRight = true;
        startX = transform.position.x;
    }

    public void MoveLeft()
    {
        //transform.position += new Vector3(-moveX, 0, 0);
        if (currentMove < 1)
        {
            //Activate retry button(Death screen)
            return;
        }
        currentMove--;
        startX = transform.position.x;
        moveLeft = true;
    }

    public void Jump()
    {
        //CanJump();
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f + collider.bounds.extents.y, groundLayer))
        {
            rb.velocity += new Vector2(0, jumpForce);
            Debug.Log("Jumped");
        }
        else
        {
            Debug.Log("Jump Failed");
        }
    }
    void CanJump()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f + collider.bounds.extents.y, groundLayer))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            moveRight = false;
            moveLeft = false;
            transform.position = startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Collectable>())
        {
            if (collision.gameObject.GetComponent<Collectable>().type == Collectable.ObjectType.Movement)
            {
                AddMove(collision.gameObject.GetComponent<Collectable>().value);
            }
        }
    }

    void AddMove(int amount)
    {
        moveAmount += amount;
        //Update the text that holds move count
    }
}
