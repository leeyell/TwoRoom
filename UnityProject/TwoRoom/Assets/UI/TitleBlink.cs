using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBlink : MonoBehaviour
{
    private Image title;
    // Start is called before the first frame update
    void Start()
    {
        title = gameObject.GetComponent<Image>();  
        StartBlinking(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator blink()
    {
        while(true)
        {
            /* float time = Random.Range(0.1f, 0.4f);
            if (time > 0.3f)
                time = 0.8f;
             switch(title.color.a.ToString())
             {
                 case "0":*/

            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.05f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.03f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.03f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.05f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.1f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.5f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.2f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.1f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.3f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.05f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.7f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.1f);

            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.3f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.1f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.03f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.05f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
            yield return new WaitForSeconds(0.1f);
            title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
            yield return new WaitForSeconds(0.2f);
            
         }
    }

    void StartBlinking()
     {
         StartCoroutine("blink");
     }
}
