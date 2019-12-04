using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Slidertimer : MonoBehaviour
{
    public Slider slTimer;
    //  float fSliderBarTime;
    // 0 : 틀린 물건 클릭
    // 1 : 평소상태
    public int currentState = 1;
    int count = 0;
    
   

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            slTimer.value = 0;
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("null");
        }
    }

    void Update()
    {
        //currentState = FindObjectOfType<GameManager>().Clickcheck;
        
        try
        {
            if (FindObjectOfType<UIManager>().runTimer == true)
            {
                if (count == 0)
                {
                    slTimer.value = 180;
                    count += 1;
                }
                if (slTimer.value > 0)
                {
                    slTimer.value -= Time.deltaTime * 10;

                    //틀린 물체 클릭시
                    if (currentState == 0)
                    {
                        Debug.Log("slidertimer의 currentState");
                        slTimer.value -= 5.0f;
                        currentState = 1;
                        //FindObjectOfType<GameManager>().Clickcheck = 2;
                    }

                    //5초 남았을 때 긴박한 음악 재생
                    if(slTimer.value < 5.0f)
                    {
                        GameObject.Find("stress").GetComponent<AudioSource>().Play();
                    }
                }
                else
                {

                    //타이머 다 됐을 때
                    FindObjectOfType<UIManager>().runTimer = false;
                    count = 0;
                    GameObject.Find("GameManager").GetComponent<GameManager>().CallFadeOut("Find");
                }

                
            }
        }
        catch(NullReferenceException ex2)
        {
            
        }
    }
}
