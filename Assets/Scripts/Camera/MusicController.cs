using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject music;
    
    // Start is called before the first frame update
    void Start()
    {
        music.SetActive(true);
        AudioListener.volume = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
