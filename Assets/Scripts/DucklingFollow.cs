using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingFollow : MonoBehaviour
{
    public float speed;
    public float distance;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > distance){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
