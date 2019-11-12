using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour { //
    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;

    public Camera fpsCam;

   void Start () {
      
   }
   
   void Update () {
        MoveCtrl();
        RotCtrl();
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