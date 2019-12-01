using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    public GameObject player;
    private Animation anim;
    private string animName;
    private bool isEntered;
    // Start is called before the first frame update
    void Start()
    {
        isEntered = false;
        anim = player.GetComponent<Animation>();
        animName = AnimationName();
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
            anim.Play(animName);
            anim.wrapMode = WrapMode.Once;

        }
    }
    

    public string AnimationName() {
        string  animName = "";
        foreach (AnimationState state in anim) {
            animName = state.name;
        }
        return animName;
    }
}