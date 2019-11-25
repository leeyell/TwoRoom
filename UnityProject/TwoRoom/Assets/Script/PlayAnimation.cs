using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{    
    private GameObject target;  // 애니메이션을 재생할 물건.
    private Animation anim;
    public AnimationClip clip;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = CastRay();
            if (target.tag == "anim") {
                anim = target.GetComponent<Animation> ();
                anim.clip = clip;
                anim.Play("Drawer1");
            }
        }
    }

    GameObject CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (hit.collider != null) { //히트되었다면 여기서 실행
            Debug.Log (hit.collider.name + " 클릭했다.");  
            return hit.collider.gameObject; // 히트 된 오브젝트를 리턴.
        }
        return null;
    }
    
}
