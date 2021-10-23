using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingFollow : DuckMovement
{
    public float followSpeed;
    public bool follow = false;
    public GameObject duckling;

    private Transform target;
    private float duckCount;
    private float distance;

    void Start()
    {
        SuperStart();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = GetMoveDirection();
        bool isBouncing = follow && IsBouncing();
        bool isSwimming = IsSwimming();

        Animate(moveDirection, isBouncing, isSwimming);
    }

    Vector2 GetMoveDirection()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return new Vector2(moveX, moveY).normalized;
    }

    void Update()
    {

        if (follow)
        {
            //follow the player
            if (Vector2.Distance(transform.position, target.position) > distance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
            }
        }
    }

    public void Follow()
    {
        follow = true;
        duckling.gameObject.tag = "IncludedDuckling";
        duckCount = PlayerPrefs.GetFloat("duckCount");
        PlayerPrefs.SetFloat("duckCount", duckCount + 0.75f);
        distance = PlayerPrefs.GetFloat("duckCount");
        animator.Play("Base Layer.DucklingBounce", 0, 1f);
    }

    public override bool IsBouncing()
    {
        return Input.GetKey("space");
    }
}
