using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int timeLeft = 180; //한 스테이지당 몇 초를 부여하는지.
    public int timePenalty = 5; //틀릴 때 마다 시간이 몇초씩 감소하는지
    public int changed_num = 5; //몇 개가 움직였는지.
    public int correct_Num = 0; //몇 개를 맞췄는지


    void Start()
    {
        GameStart();
    }

    void Update()
    {
        
    }

    // 집 전체에서 5개.. 

    public void Correct(GameObject obj){
        correct_Num++;

        // 오브젝트 정답 처리 (outline)
        GameObject.Find(obj.name).GetComponent<Shiftable>().Found();

        GameObject.Find("UIManager").GetComponent<UIManager>().Correct();

        if (correct_Num == changed_num){ //clear
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

    IEnumerator FadeOut(){
        Debug.Log("FadeOut Called");
        GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFadeOutAnim();
        yield return new WaitForSeconds(2f);

        //player.transform.position = tr.position;
        Debug.Log("FadeIn Called");
        GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFadeInAnim();
        yield return new WaitForSeconds(2f);
    }
    void GameStart(){
        // 컷씬
        StartCoroutine("FadeOut");


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
        // ======================
        // * 현관문 열림
        // * 타이머 멈춤
        // * (먼가 UI 변화)
        // ======================
    }
    void GameOver(){
        // ==================
        // * OR.CancelShift();
        // 씬 전환 (이후 구현 ㄴㄴ)
        // ==================
    }

}
