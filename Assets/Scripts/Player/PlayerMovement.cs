using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D rigidbody;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = GetMoveDirection();
        bool isBouncing = IsBouncing();
        bool isSwimming = IsSwimming();

        Move(moveDirection);
        Animate(moveDirection, isBouncing, isSwimming);


    }

    Vector2 GetMoveDirection()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return new Vector2(moveX, moveY).normalized;
    }

    void Move(Vector2 moveDirection)
    {
        rigidbody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Animate(Vector2 moveDirection, bool isBouncing, bool isSwimming)
    {
        if (moveDirection.magnitude > 0)
        {
            animator.SetBool("isWaddling", true);

            if (moveDirection.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            } else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        } else
        {
            animator.SetBool("isWaddling", false);
        }

        animator.SetBool("isBouncing", isBouncing);

        animator.SetBool("isSwimming", isSwimming);
    }

    bool IsBouncing()
    {
        return Input.GetKey("space");
    }

    bool IsSwimming()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Water")
            {
                return true;
            } else {
                return false;
            }
        } else
        {
            return false;
        }
    }
}
