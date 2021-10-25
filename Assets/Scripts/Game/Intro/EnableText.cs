using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableText : MonoBehaviour
{
    public GameObject textUI;
    public GameObject waypoint;

    void Start(){
        textUI.SetActive(false);
    }

    void Update(){
        if (transform.position == waypoint.transform.position){
            textUI.SetActive(true);
        }
    }
}
