using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach to empty game object in Start Menu
public class SetInitial : MonoBehaviour
{
    // Setting initial PlayerPrefs
    void Start()
    {
        PlayerPrefs.DeleteAll();
        //Set duckCount = 0 at start
        PlayerPrefs.SetFloat("duckCount", 0);
        //Set dropRadius = 0 at start
        PlayerPrefs.SetFloat("dropRadius", 0);  
        //Set sceneTransition = 0 at start
        PlayerPrefs.SetInt("sceneTransition", 0); 
    }
}
