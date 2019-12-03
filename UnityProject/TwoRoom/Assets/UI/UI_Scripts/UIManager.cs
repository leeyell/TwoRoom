using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool runTimer = false;
    public Dialogue dialogue;
    //맞았을 때 실행되는 함수-현재 상태 바 하나씩 늘어남
    public void Correct()
    {
        FindObjectOfType<StateManager>().ChangeState();
    }
    //틀렸을 때 실행되는 함수 - 무서운효과 발생(ex. 불깜박이기, 무서운소리나기)/타임바 줄어듦
    public void Uncorrect()
    {
        Debug.Log("uncorrect 함수 실행");
        //타임바 줄어들게하는 함수
        GameObject.Find("Slider").GetComponent<Slidertimer>().currentState = 0;
        Debug.Log(FindObjectOfType<Slidertimer>().currentState);
        int index = Random.Range(0, 2);
        Debug.Log(index);
        if (index == 1)
            GameObject.Find("Knock").GetComponent<AudioSource>().Play();
        else if(index == 0)
            GameObject.Find("Kwang").GetComponent<AudioSource>().Play();
        else
            FindObjectOfType<LightBlink>().Blink();
    }
    public void StartTimer()
    {
        runTimer = true;
    }

    public void StartDialogue()
    {
        Debug.Log("startdialogue 함수");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
