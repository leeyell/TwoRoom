using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public Animator dialogueanimator;
    public Animator biganimator;
    public Text windowText;
   
    public string currsentence;
    public bool endSentence = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //애니메이터 실행
        dialogueanimator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        //dialogue 객체에 달려 있는 문장들 넣기
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //처음 대화 보여줌
        DisplayNextSentence(0);
    }
    
    public void ShowFullWindow(Dialogue dialogue)
    {
        //애니메이터 실행
        biganimator.SetBool("IsOpen", true);

        sentences.Clear();

        //dialogue 객체에 달려 있는 문장들 넣기
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //처음 대화 보여줌

        WindowDisplayNextSentence(0);
    }

    public void DisplayNextSentence(int count)
    {

        //더이상 보여줄 대사가 없을 때
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //처음 대사 실행, 대사를 다 본 뒤 다음 대사를 보려할 때
        if(count == 0 || count == 2 || endSentence == true)
        {
            string sentence = sentences.Dequeue();
            currsentence = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        //대사가 다 안나왔는데 나머지 대사를 다 보고 싶을 때
        else
        {
            StopAllCoroutines();
            dialogueText.text = currsentence;
        }
       
    }

    public void WindowDisplayNextSentence(int count)
    {

        //더이상 보여줄 대사가 없을 때
        if (sentences.Count == 0)
        {
            EndShowWindow();
            return;
        }

        //처음 대사 실행, 대사를 다 본 뒤 다음 대사를 보려할 때
        if (count == 0 || count == 2 || endSentence == true)
        {
            string sentence = sentences.Dequeue();
            currsentence = sentence;
            StopAllCoroutines();
            StartCoroutine(WindowTypeSentence(sentence));
        }

        //대사가 다 안나왔는데 나머지 대사를 다 보고 싶을 때
        else
        {
            StopAllCoroutines();
            windowText.text = currsentence;
        }

    }

    //대사 한글자씩 나오게
    IEnumerator TypeSentence(string sentence)
    {
        endSentence = false;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        endSentence = true;
        Debug.Log(endSentence);
    }

    IEnumerator WindowTypeSentence(string sentence)
    {
        endSentence = false;
        windowText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            windowText.text += letter;
            yield return null;
        }
        endSentence = true;
        Debug.Log(endSentence);
    }

    void EndDialogue()
    {
        dialogueanimator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
    }

    void EndShowWindow()
    {
        biganimator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
    }
}
