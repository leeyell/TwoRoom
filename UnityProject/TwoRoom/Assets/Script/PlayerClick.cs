using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public GameObject Text; // 클릭 시 반응할 오브젝트 (풀로 설정 변경 필요)
    private GameObject target;
    private Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            target = GetClickObject();
            Debug.Log(target.tag);

            if (target.tag == "Clickable")
            {
                Debug.Log("Player Clicked Object");
                // 플레이어가 오브젝트 클릭 시 발생할 이벤트 구현
                // Outline Shader 여기에 구현
            } else
            {

            }

            if (target.GetComponent<Outline>() != null)
            {
                outline = target.GetComponent<Outline>();
                Destroy(outline);
            } else
            {
                outline = target.AddComponent<Outline>();
                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor = Color.green;
                outline.OutlineWidth = 20f;
            }
        }
    }

    private GameObject GetClickObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}
