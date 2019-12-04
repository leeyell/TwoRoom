using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //true로 설정시 타이머 실행
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

        //무서운 효과 발생
        // FindObjectOfType<EffectManager>().PlaySound();
        // FindObjectOfType<EffectManager>().PlayLight();
        

        /*
        Debug.Log(FindObjectOfType<Slidertimer>().currentState);

        int index = Random.Range(0, 2);
        Debug.Log(index);
        if (index == 1)
            GameObject.Find("Knock").GetComponent<AudioSource>().Play();
        else if(index == 0)
            GameObject.Find("Kwang").GetComponent<AudioSource>().Play();
        else
            FindObjectOfType<LightBlink>().Blink();
 */   
    }

    //타이머 시작하는 함수
    public void StartTimer()
    {
        runTimer = true;
    }

    //대화시작하는 함수
    public void StartDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void StartShowWindow(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().ShowFullWindow(dialogue);
    }
    
    //책 UI로 띄워주는 함수
    public void OpenBook()
    {
        GameObject.Find("UIBookP").transform.Find("UIBook").gameObject.SetActive(true);
    }


}
