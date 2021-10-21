using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : DuckMovement
{
    // Start is called before the first frame update
    void Start()
    {
        SuperStart();
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

    public override bool IsBouncing()
    {
        return Input.GetKey("space");
    }
}
