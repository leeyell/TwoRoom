using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    int correctNum = 0;
    public Image stateImage1;
    public Image stateImage2;
    public Image stateImage3;
    public Image stateImage4;
    public Image stateImage5;
    public Image correctImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeState()
    {
        correctNum += 1;
        if (correctNum == 1)
        {
            stateImage1.sprite = correctImage.sprite;
        }
        if (correctNum == 2)
        {
            stateImage2.sprite = correctImage.sprite;
        }
        if (correctNum == 3)
        {
            stateImage3.sprite = correctImage.sprite;
        }
        if (correctNum == 4)
        {
            stateImage4.sprite = correctImage.sprite;
        }
        if (correctNum == 5)
        {
            stateImage5.sprite = correctImage.sprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
