using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 250f;
    public Animator animator;

    private int current = 0;
    private float WPradius = 1;
	
    void Start() {
        animator = GetComponent<Animator>();
    }
	void Update () {
		if(Vector2.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        animator.SetBool("isWaddling", true);
        if(transform.position == waypoints[current].transform.position){
            animator.SetBool("isWaddling", false);
        }
    }
}
