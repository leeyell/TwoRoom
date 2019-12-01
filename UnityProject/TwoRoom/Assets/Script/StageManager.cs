using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Text timeText;

    private GameObject player;
    private Transform tr;
    private float time;
    private GameObject fadeOut;
    private
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        GameObject temp = GameObject.Find("Stage1Start");
        tr = temp.transform;


        time = 0;
    }

    IEnumerator FadeOut()
    {
        GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFadeOutAnim();
        yield return new WaitForSeconds(2f);

        player.transform.position = tr.position;

        GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFadeInAnim();
        yield return new WaitForSeconds(2f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "시간 : " + Mathf.Round(time);
        if (time >= 1000)
        {
            StartCoroutine("FadeOut");
            time = 0;
        }
    }
}
