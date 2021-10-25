using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuUI;
    public static bool paused = false;
   // PauseAction action;
    public GameObject button;

    /**private void Start()
    {
       // action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    // Update is called once per frame
    **/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void DeterminePause()
    {
        if (paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        button.SetActive(true);

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        button.SetActive(false);
        // GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
