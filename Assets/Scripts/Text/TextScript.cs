using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextScript : MonoBehaviour
{
    public float timer = 0f;

    private float duckCount;

    void Update()
    {
        switch(this.name)
        {
            case "DucklingsCollected":
                duckCount = PlayerPrefs.GetFloat("duckCount");
                this.GetComponent<UnityEngine.UI.Text>().text = duckCount.ToString() + "/9";
                break;
            case "Timer":
                if (timer > 0) {
                    timer -= Time.deltaTime;
                    float minutes = Mathf.FloorToInt(timer / 60);
                    float seconds = Mathf.FloorToInt(timer % 60);

                    this.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
                }
                else {
                    this.GetComponent<UnityEngine.UI.Text>().text = string.Format("00:00");
                    SceneManager.LoadScene("End");
                }
                break;
            case "DucksCollectedShadow":
                duckCount = PlayerPrefs.GetFloat("duckCount");
                this.GetComponent<TMP_Text>().text = "Total Ducklings: " + duckCount.ToString() + "/9";
                break;
            case "DucksCollectedTitle":
                duckCount = PlayerPrefs.GetFloat("duckCount");
                this.GetComponent<TMP_Text>().text = "Total Ducklings: " + duckCount.ToString() + "/9";
                break;
        }
    }
}
