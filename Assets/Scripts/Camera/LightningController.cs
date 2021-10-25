using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public GameObject lightning;

    public GameObject audioOne;
    public GameObject constantRain;

    private void Start()
    {
        lightning.SetActive(false);
        audioOne.SetActive(false);
        constantRain.SetActive(true);

        Invoke("callLightning", 2f);
    }

    void callLightning()
    {
        int r = Random.Range(0, 3);

        if (r == 0)
        {
            lightning.SetActive(true);
            Invoke("endLightning", .125f);
            Invoke("callThunder", .395f);
        }

        else if (r == 1)
        {
            lightning.SetActive(true);
            Invoke("endLightning", .105f);
            Invoke("callThunder", .195f); 
        }

        else
        {
            lightning.SetActive(true);
            Invoke("endLightning", .75f);
            callThunder();
        }

    }

    void endLightning()
    {
        lightning.SetActive(false);

        float rand = Random.Range(9f, 24f);
        Invoke("callLightning", rand);
    }



    void callThunder()
    {
        audioOne.SetActive(true);
        Invoke("endThunder", 8.5f);
    }

    void endThunder()
    {
        audioOne.SetActive(false);
    }

}
