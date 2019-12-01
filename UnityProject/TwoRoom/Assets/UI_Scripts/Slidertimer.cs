using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Slidertimer : MonoBehaviour
{
    public Slider slTimer;
    //  float fSliderBarTime;
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
                    if (currentState == 0)
                    {
                        Debug.Log("slidertimer의 currentState");
                        slTimer.value -= 5.0f;
                        currentState = 1;
                        //FindObjectOfType<GameManager>().Clickcheck = 2;
                    }
                }
                else
                {
                    FindObjectOfType<UIManager>().runTimer = false;
                    count = 0;
                }
            }
        }
        catch(NullReferenceException ex2)
        {
            
        }
    }
}
