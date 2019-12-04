using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    int correctNum = 0;
    public Image stateImage;
    public Sprite stateImage1;
    public Sprite stateImage2;
    public Sprite stateImage3;
    public Sprite stateImage4;
    public Sprite stateImage5;


    public void ChangeState()
    {
        correctNum += 1;
        if (correctNum == 1)
        {
            stateImage.sprite = stateImage1;
        }
        if (correctNum == 2)
        {
            stateImage.sprite = stateImage2;
        }
        if (correctNum == 3)
        {
            stateImage.sprite = stateImage3;
        }
        if (correctNum == 4)
        {
            stateImage.sprite = stateImage4;
        }
        if (correctNum == 5)
        {
            stateImage.sprite = stateImage5;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
