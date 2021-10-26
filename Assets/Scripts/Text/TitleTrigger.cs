using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTrigger : MonoBehaviour
{
    public GameObject winShadow;
    public GameObject winTitle;
    public GameObject loseShadow;
    public GameObject loseTitle;

    private float duckCount;

    void Start()
    {
        winShadow.SetActive(false);
        winTitle.SetActive(false);
        loseShadow.SetActive(false);
        loseTitle.SetActive(false);
    }

    void Update()
    {
        duckCount = PlayerPrefs.GetFloat("duckCount");
        if (duckCount < 9) {
            loseShadow.SetActive(true);
            loseTitle.SetActive(true);
        }
        else {
            winShadow.SetActive(true);
            winTitle.SetActive(true);
        }
    }
}
