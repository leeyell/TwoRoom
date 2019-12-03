using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("눌림");
        FindObjectOfType<UIManager>().StartDialogue();
    }
}
