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

    void Start()
    {
        //PastPos 기억
        for (int i = 0; i < RandomObjects.Length; i++){
            PastPos[i] = RandomObjects[i].transform.position;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RandomShift();
        }   
        if (Input.GetKeyDown(KeyCode.E))
        {
            CancelShift();
        }      
    }

    void RandomShift(){
        shiftIndex = Random.Range(0, RandomObjects.Length);
        Debug.Log("바뀌기 전 : " + RandomObjects[shiftIndex].transform.position);
        RandomObjects[shiftIndex].transform.position = RandomPos[shiftIndex].transform.position;
        Debug.Log("바뀐 후 : " + RandomObjects[shiftIndex].transform.position);
        Debug.Log(shiftIndex);

        RandomObjects[shiftIndex].GetComponent<Shiftable>().Shift();
    }
    void CancelShift(){
        Debug.Log("Cancel");
        for (int i = 0; i < RandomObjects.Length; i++){
            RandomObjects[i].transform.position = PastPos[i];

            RandomObjects[i].GetComponent<Shiftable>().Unshift();
            RandomObjects[i].GetComponent<Shiftable>().RemoveEffect();
        }
    }
}
