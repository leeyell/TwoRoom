using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiftable : MonoBehaviour
{

    public bool shifted = false;
    public bool found = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shift(){
        Debug.Log(this.name + " 옮겨진다..잘 봐라");
        shifted = true;
    }
    public void Unshift(){
        found = false;
        Debug.Log(this.name + " 다시 돌아간다.. 잘 봐라..");
        shifted = false;
    }
    public void Found(){
        found = true;
        shifted = false; // 중복 맞춤 방지..
        Effect();
    }
    void Effect(){
        // outline 효과
        Debug.Log("아웃라인");
        Outline outline = this.gameObject.AddComponent<Outline>();//target.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = 20f;

    }
    public void RemoveEffect(){
        Outline outline = this.gameObject.GetComponent<Outline>();
        if (outline != null){
            Destroy(outline);
        }
    }
}
