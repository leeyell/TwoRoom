using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    public GameObject player;
    private Animation anim;
    private string[] animNames;
    private bool isEntered;
    // Start is called before the first frame update
    void Start()
    {
        isEntered = false;
        anim = player.GetComponent<Animation>();
        animNames = AnimationName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (!isEntered && coll.gameObject.tag == "Player") 
        {
            Debug.Log("플레이어가 창고 앞에 섰다리");
            isEntered = true;
            anim.Play(animNames[0]);
            anim.wrapMode = WrapMode.Once;

        }
    }
    

    public string[] AnimationName() {
        string  animName = "";
        string[] animNames = new string[2];
        int index = 0;
        foreach (AnimationState state in anim) {
            animName = state.name;
            animNames[index] = animName;
            index++;
        }
        return animNames;
    }
}