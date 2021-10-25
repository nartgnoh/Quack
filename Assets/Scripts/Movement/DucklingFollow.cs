using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingFollow : DuckMovement
{
    public float followSpeed;
    public bool follow = false;
    public GameObject duckling;
    public float soundRadius = 10f;
    public GameObject cryingSound;

    private Transform target;
    private float duckCount;
    private float followDistance;
    private float dropRadius;
    private AudioSource chirpSound;
    private AudioSource audio;

    void Start()
    {
        SuperStart();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        chirpSound = duckling.gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = GetMoveDirection();
        bool isBouncing = follow && IsBouncing();
        bool isSwimming = IsSwimming();

        if(follow) {
            Animate(moveDirection, isBouncing, isSwimming);
        }
    }

    Vector2 GetMoveDirection()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return new Vector2(moveX, moveY).normalized;
    }

    void Update()
    {
        //Duckies Sorting Layer
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        //Get dropRadius
        dropRadius = PlayerPrefs.GetFloat("dropRadius");
        if(follow) {
            if(Vector2.Distance(transform.position, target.position) > dropRadius) {
                //drop duckling
                duckling.gameObject.tag = "Duckling";
                duckling.gameObject.GetComponent<BoxCollider2D>().enabled = true;

                //get and update duckling count
                duckCount = PlayerPrefs.GetFloat("duckCount");
                PlayerPrefs.SetFloat("duckCount", duckCount-1);
                //sounds
                if (!GameObject.Find("CryingSound(Clone)")){
                    Instantiate(cryingSound, transform.position, Quaternion.identity);
                    audio = cryingSound.gameObject.GetComponent<AudioSource>();
                    Destroy(GameObject.Find("CryingSound(Clone)"), audio.clip.length);
                }
                chirpSound.Play();

                follow = false;
            }          
            else if(Vector2.Distance(transform.position, target.position) > followDistance) {
                //follow the player
                chirpSound.Stop();
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
        //disable chirp sound
        Destroy(GameObject.Find("ChirpSound(Clone)"));

        //get and update duckling count
        duckCount = PlayerPrefs.GetFloat("duckCount");
        PlayerPrefs.SetFloat("duckCount", duckCount+1);
        //set followDistance
        followDistance = PlayerPrefs.GetFloat("duckCount")*0.75f;
        //get and update drop radius
        PlayerPrefs.SetFloat("dropRadius", followDistance + 2);
        
        animator.Play("Base Layer.DucklingBounce", 0, 1f);
        follow = true;
    }

    public override bool IsBouncing()
    {
        return Input.GetKey("space");
    }
}
