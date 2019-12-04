using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public int count = 0;
    public void OnMouseDown()
    {
        Debug.Log("눌림");
        count++;
        FindObjectOfType<DialogueManager>().DisplayNextSentence(count);
        if (count == 2)
            count = 0;
    }
}
