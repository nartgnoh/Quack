using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class IntroText : MonoBehaviour
{
    public Text text;
    public GameObject duck;

    private string[] story;
    private int count = 0;
    private AudioSource duckSound;
    private int sceneTransition;
    
    void Start() {
        story = new string[] {
            "My ducklings are missing...",
            "I have to find them...",
            "Quack!"
        };

        text.text = story[count];
        count++;
        duckSound = duck.gameObject.GetComponent<AudioSource>();
    }

	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            duckSound.Play();
            if(story.Length > count) {
                StartCoroutine(Wait()); 
            }
            else {
                PlayerPrefs.SetInt("sceneTransition", 1); 
            }
        }
    }

    IEnumerator Wait()
    {
        StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
        yield return new WaitForSeconds(1);
        if(story.Length > count) {
            text.text = story[count];
        }
        count++;
        StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
 