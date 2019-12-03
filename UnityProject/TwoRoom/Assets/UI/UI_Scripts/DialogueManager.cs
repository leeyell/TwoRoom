using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public Animator animator;
    public string currsentence;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //애니메이터 실행
        Debug.Log("애니메이터 실행");
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(0);
    }

    public void DisplayNextSentence(int count)
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if(count == 0 || count == 2)
        {
            string sentence = sentences.Dequeue();
            currsentence = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));    
        }

        else
        {
            StopAllCoroutines();
            dialogueText.text = currsentence;
        }        
    }

    //대사 한글자씩 나오게
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
    }
}
