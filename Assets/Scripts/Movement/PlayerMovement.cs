using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : DuckMovement
{
    public float quackRadius;
    private HashSet<int> seenDucklings;
    void Start()
    {
        SuperStart();

        seenDucklings = new HashSet<int>();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = GetMoveDirection();
        bool isBouncing = IsBouncing();
        bool isSwimming = IsSwimming();

        Move(moveDirection);
        Quack(isBouncing);
        Animate(moveDirection, isBouncing, isSwimming);
    }

    Vector2 GetMoveDirection()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return new Vector2(moveX, moveY).normalized;
    }

    public override bool IsBouncing()
    {
        return Input.GetKey("space");
    }

    void Quack(bool isBouncing)
    {
        if (!isBouncing)
        {
            return;
        }

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, quackRadius);

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.tag == "Duckling" && !seenDucklings.Contains(collider.GetInstanceID()))
            {
                seenDucklings.Add(collider.GetInstanceID());
                collider.GetComponent<DucklingFollow>().Follow();
            }
        }
    }
}
