using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int timeLeft = 180; //한 스테이지당 몇 초를 부여하는지.
    public int timePenalty = 5; //틀릴 때 마다 시간이 몇초씩 감소하는지
    public int changed_num = 5; //몇 개가 움직였는지.
    public int correct_Num = 0; //몇 개를 맞췄는지
    public bool memorize;

    void Start()
    {
        GameStart();
    }

    void Update()
    {
        
    }

    public void Correct(GameObject obj){
        correct_Num++;

        GameObject.Find(obj.name).GetComponent<Shiftable>().Found();
        if (GameObject.Find(obj.name).GetComponent<Shiftable>() == null){
            Debug.Log("님 개망함  ㅋㅋ");
        }

        GameObject.Find("UIManager").GetComponent<UIManager>().Correct();

        if (correct_Num == changed_num){ 
            GameClear();
        }
    }
    public void Uncorrect(){
        timeLeft -= timePenalty;
        // =================================
        // * UI 변화 
        // * 공포 특수효과
        // =================================
        if (timeLeft < 0){
            GameOver();
        }
    }
    public void CallFadeOut(string status){
        StartCoroutine(FadeOut(status));
    }
    IEnumerator FadeOut(string status){
        Debug.Log("FadeOut Called");
        GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFadeOutAnim();
        yield return new WaitForSeconds(2f);
        // 이미 방을 1분 동안 외운 상태, 이제 찾을거임. 플레이어 위치 리셋하고 랜덤으로 물건 위치 바꿈.
        if (status == "Find") {
            GameObject.Find("Player").GetComponent<ObjectRandomShift>().RandomShift();
            CallResetPos();
        }
        // 님 이미 졌고, 1분 줄 테니까 다시 외우셈. 
        else {
            CallResetPos();
            GameObject.Find("Player").GetComponent<ObjectRandomShift>().CancelShift();

        }
        //player.transform.position = tr.position;
        Debug.Log("FadeIn Called");
        GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFadeInAnim();
        yield return new WaitForSeconds(2f);
    }
    void GameStart(){
        // 컷씬
        // CallFadeOut();
        // * 문잠구기
        FindObjectOfType<UIManager>().StartTimer();
        Debug.Log("나오면 뒤진다");
        // ==================
        // * (1분 타이머 코루틴 호출)
        //     바뀌기 전 방 보여주는 용도
        //     코루틴 끝나면, 플레이어 위치 원래대로 돌려야함.
        // ==================

        // ===============================
        // * OR.RandomShift(); 
        // ===============================

        // ===================
        // * 타이머 재시작
        // ===================
        
    }
    void GameClear(){
        GameObject.FindGameObjectWithTag("HGdoor").GetComponent<CottageDoor>().isOpened = true;
        // ======================
        // * 문 열림
        // * 타이머 멈춤
        // * (먼가 UI 변화)
        // ======================
    }
    void GameOver(){
        // 다시 외우는 구간으로 넘어감.
        CallFadeOut("Memorize");
        // * 씬 전환 (이후 구현 ㄴㄴ)
        // ==================
    }
    // 페이드인 아웃
    // 플레이어 자리를 원래대로 돌린다
    public void StartToFind(){
        // 바뀐 걸 찾는 구간으로 넘어감.
        CallFadeOut("Find");
    }
    void CallResetPos(){
        GameObject.Find("Player").GetComponent<PlayerController>().ResetPos();
    }


}
