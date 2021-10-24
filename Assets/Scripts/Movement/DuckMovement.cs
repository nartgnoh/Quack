using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DuckMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody2D rigidbody;
    public Animator animator;

    public void SuperStart()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Move(Vector2 moveDirection)
    {
        rigidbody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void Animate(Vector2 moveDirection, bool isBouncing, bool isSwimming)
    {
        if (moveDirection.magnitude > 0)
        {
            animator.SetBool("isWaddling", true);

            if (moveDirection.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            animator.SetBool("isWaddling", false);
        }

        animator.SetBool("isBouncing", isBouncing);

        animator.SetBool("isSwimming", isSwimming);
    }

    public abstract bool IsBouncing();

    public bool IsSwimming()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Water")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
