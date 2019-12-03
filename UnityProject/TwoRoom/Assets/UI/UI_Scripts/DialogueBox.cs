using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            complete();
        }
    }
   public int count = 0;
   
   public void complete()
   {
       count++;
       Debug.Log("찍히니?");
       FindObjectOfType<DialogueManager>().DisplayNextSentence(count);

       if(count == 2)
            count = 0;
   }
}
