using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int sceneTransition;

    void Update() {
        sceneTransition = PlayerPrefs.GetInt("sceneTransition");

        if (sceneTransition == 1)
        {
            PlayerPrefs.SetInt("sceneTransition", 0); 
            FadeToLevel();
        }
    }

    public void FadeToLevel() {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
