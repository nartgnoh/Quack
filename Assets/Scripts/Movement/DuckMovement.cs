using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DuckMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    private GameObject shadow;

    public Rigidbody2D rigidbody;
    public Animator animator;

    public bool isBouncing;

    public void SuperStart()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        foreach (Transform child in transform)
        {
            if (child.name == "Shadow")
            {
                shadow = child.gameObject;
                break;
            }
        }
    }

    public void Move(Vector2 moveDirection)
    {
        rigidbody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void Animate(Vector2 moveDirection, bool isBouncing, bool isSwimming)
    {
        this.isBouncing = isBouncing;
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

        if (isSwimming)
        {
            shadow.SetActive(false);
        }
        else
        {
            shadow.SetActive(true);
        }

        animator.SetBool("isBouncing", isBouncing && !isSwimming);

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
