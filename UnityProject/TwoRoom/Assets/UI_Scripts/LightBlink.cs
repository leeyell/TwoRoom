using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{

    public Light light;
   
    IEnumerator ShowReady()
    {
        int count = 0;
        while(count < 5)
        {
            float time1 = Random.Range(0.3f, 0.8f);
            light.color = Color.black;
            yield return new WaitForSeconds(time1);
            light.color = Color.blue;
            float time2 = 0.1f;
            yield return new WaitForSeconds(time2);
            count++;
        }
    }

    public void Blink()
    {
        Debug.Log("blink function");
        StartCoroutine(ShowReady());
    }
}
