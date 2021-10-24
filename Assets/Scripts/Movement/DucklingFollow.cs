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
    private float followDistance;
    private float dropRadius;

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
        if(follow) {
            if(Vector2.Distance(transform.position, target.position) > dropRadius) {
                duckling.gameObject.tag = "Duckling";
                duckling.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                //get and update duckling count
                duckCount = PlayerPrefs.GetFloat("duckCount");
                PlayerPrefs.SetFloat("duckCount", duckCount-1);
                follow = false;
            }          
            else if(Vector2.Distance(transform.position, target.position) > followDistance) {
                //follow the player
                transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
            }
        }

    }

    public void Follow()
    {
        //change duckling tag to "IncludedDuckling"
        duckling.gameObject.tag = "IncludedDuckling";
        //disable boxCollider on duckling
        duckling.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        //get and update duckling count
        duckCount = PlayerPrefs.GetFloat("duckCount");
        PlayerPrefs.SetFloat("duckCount", duckCount+1);
        //set followDistance
        followDistance = PlayerPrefs.GetFloat("duckCount")*0.75f;
        //set dropRadius
        dropRadius = followDistance + 2;
        
        animator.Play("Base Layer.DucklingBounce", 0, 1f);
        follow = true;
    }

    public override bool IsBouncing()
    {
        return Input.GetKey("space");
    }
}
