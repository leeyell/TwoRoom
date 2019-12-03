using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random=UnityEngine.Random;

public class ObjectRandomShift : MonoBehaviour
{
    int shiftIndex = -1; //위치가 바뀐 오브젝트의 인덱스..

    public GameObject[] RandomObjects;
    public GameObject[] RandomPos;
    Vector3[] PastPos = new Vector3[100]; //Start 오브젝트가 움직이기 전의 포지션 (for loop으로 저장)
    Quaternion[] PastRot = new Quaternion[100]; // 지상렬

    void Start()
    {
        //PastPos 기억
        for (int i = 0; i < RandomObjects.Length; i++){
            PastPos[i] = RandomObjects[i].transform.position;
            PastRot[i] = RandomObjects[i].transform.rotation; //  지상렬
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RandomShift();
        }   
        if (Input.GetKeyDown(KeyCode.R))
        {
            CancelShift();
        }      
    }

    public void RandomShift(){
        int count = 0;
        string indexString = "";
        while(count < 5){ // 5개 만큼 바꾸기.
            int[] indexList = new int[5];

            shiftIndex = Random.Range(0, RandomObjects.Length);

            if (!indexString.Contains(shiftIndex.ToString())){
                indexList[count] = shiftIndex;
                indexString = indexString + "*" + shiftIndex;
                Debug.Log("인덱스 다 합친거 : " + indexString);
                count++;
                RandomObjects[shiftIndex].transform.position = RandomPos[shiftIndex].transform.position;
                RandomObjects[shiftIndex].transform.rotation = RandomPos[shiftIndex].transform.rotation; // 지상렬

                Debug.Log(shiftIndex);

                RandomObjects[shiftIndex].GetComponent<Shiftable>().Shift();
            }
        }
    }
    public void CancelShift(){
        Debug.Log("Cancel");
        for (int i = 0; i < RandomObjects.Length; i++){
            RandomObjects[i].transform.position = PastPos[i];
            RandomObjects[i].transform.rotation = PastRot[i]; // 지상렬

            RandomObjects[i].GetComponent<Shiftable>().Unshift();
            RandomObjects[i].GetComponent<Shiftable>().RemoveEffect();
        }
    }
}
