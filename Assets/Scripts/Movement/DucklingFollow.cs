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

    void Start()
    {
        SuperStart();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = GetMoveDirection();
        bool isBouncing = IsBouncing();
        bool isSwimming = IsSwimming();

        Animate(moveDirection, isBouncing, isSwimming);
    }

    Vector2 GetMoveDirection(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return new Vector2(moveX, moveY).normalized;
    }

    void Update()
    {
        if(follow) {
            //follow the player
            if(Vector2.Distance(transform.position, target.position) > followDistance) {
                transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && duckling.gameObject.tag == "Duckling") {
            duckling.gameObject.tag = "IncludedDuckling";
            duckling.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            duckCount = PlayerPrefs.GetFloat("duckCount");
            PlayerPrefs.SetFloat("duckCount", duckCount+0.75f);
            followDistance = PlayerPrefs.GetFloat("duckCount");

            follow = true;
        }
    }

    public override bool IsBouncing()
    {
        return Input.GetKey("space");
    }
}
