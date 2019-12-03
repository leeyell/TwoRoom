using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour { //
    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;
    public Camera fpsCam;

    public Rigidbody rb;

	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	    rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            GameObject obj = CastRay();
            ClickEvent(obj);
        }
        MoveCtrl();
        RotCtrl();
    }

    GameObject CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (hit.collider != null) { //히트되었다면 여기서 실행
            //Debug.Log (hit.collider.name + " 클릭했다.");  
            return hit.collider.gameObject; // 히트 된 오브젝트를 리턴.
        }
        return null;
    }

    void ClickEvent(GameObject obj){ //래이캐스트가 맞춘 오브젝트  

        string obj_name = obj.name;

        if (obj.transform.parent != null && obj.transform.parent.name != "BeforeChange"){ //부모가 있으면, obj를 obj의 부모로 갈아끼움.
            obj_name = obj.transform.parent.name;
            obj = obj.transform.parent.gameObject; 
        }      

        Debug.Log("맞은 오브젝트 이름 : " + obj_name);

        //GameObject.Find(obj.name).GetComponent<PlayerScript>().Func();

        //래이캐스트 맞은애가 Shiftable 스크립트를 가짐.
        if (obj.GetComponent<Shiftable>() != null) { 
            if (obj.GetComponent<Shiftable>().found){ //이미 맞춤.
                Debug.Log("이미 맞춘 애야;");
            }
            else if (obj.GetComponent<Shiftable>().shifted){ // 정답임.
                Debug.Log("정답");
                GameObject.Find("GameManager").GetComponent<GameManager>().Correct(obj);
            }
            else{ // 후보임;;
                Debug.Log("얜 후보인데 아직 안움직임, 오답");
                GameObject.Find("GameManager").GetComponent<GameManager>().Uncorrect();
            }
        }
        else{
            Debug.Log("오답");
            GameObject.Find("GameManager").GetComponent<GameManager>().Uncorrect();
        }
    }


    void MoveCtrl() { //키보드 W,S,A,D Player 이동 함수
        if (Input.GetKey(KeyCode.W))
        {
            //this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // 이게 right ㄷㄷ
            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); // 이게 left ㄷㄷ;;
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.A))
        {
            //this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // 이게 forward;
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // 이게 backward ㄷㄷ;;
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

    }

    void RotCtrl() { //마우스 회전 시점이동 함수
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        fpsCam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
    }
}