using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    public class FadeOut : MonoBehaviour
    {
        

        public float animTime = 2f;         // Fade 애니메이션 재생 시간 (단위:초).  

        private Image fadeImage;            // UGUI의 Image컴포넌트 참조 변수.  

        private float OutStart = 0f;           // Mathf.Lerp 메소드의 첫번째 값.  
        private float OutEnd = 1f;             // Mathf.Lerp 메소드의 두번째 값.  
        private float OutTime = 0f;

        private float InStart = 1f;
        private float InEnd = 0f;
        private float InTime = 0f;            // Mathf.Lerp 메소드의 시간 값.  

        private bool isPlaying = false;     // Fade 애니메이션의 중복 재생을 방지하기위해서 사용.  

        void Awake()
        {
            // Image 컴포넌트를 검색해서 참조 변수 값 설정.  
            fadeImage = GetComponent<Image>();
        }

        public bool GetPlaying()
        {
            return this.isPlaying;
        }

        // Fade 애니메이션을 시작시키는 메소드.  
        

        // Fade 애니메이션 메소드.  
        IEnumerator PlayFadeOut()
        {
            // 애니메이션 재생중.  
            isPlaying = true;

            // Image 컴포넌트의 색상 값 읽어오기.  
            Color color = fadeImage.color;
            OutTime = 0f;
            color.a = Mathf.Lerp(OutStart, OutEnd, OutTime);

            while (color.a < 1f)
            {
                // 경과 시간 계산.  
                // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
                OutTime += Time.deltaTime / animTime;

                // 알파 값 계산.  
                color.a = Mathf.Lerp(OutStart, OutEnd, OutTime);
                // 계산한 알파 값 다시 설정.  
                fadeImage.color = color;

                yield return null;
            }

            // 애니메이션 재생 완료.  
            isPlaying = false;
        }

        IEnumerator PlayFadeIn()
        {
            Debug.Log("FadeIn");
            // 애니메이션 재생중.   
            isPlaying = true;
            // Image 컴포넌트의 색상 값 읽어오기.  
            Color color = fadeImage.color;
            InTime = 0f;
            color.a = Mathf.Lerp(InStart, InEnd, InTime);

            while (color.a > 0f)
            {
                // 경과 시간 계산.  
                // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
                InTime += Time.deltaTime / animTime;

                // 알파 값 계산.  
                color.a = Mathf.Lerp(InStart, InEnd, InTime);
                // 계산한 알파 값 다시 설정.  
                fadeImage.color = color;

                yield return null;
            }

            // 애니메이션 재생 완료.  
            isPlaying = false;
        }

    public void StartFadeOutAnim()
    {
        // 애니메이션이 재생중이면 중복 재생되지 않도록 리턴 처리.  
        if (isPlaying == true)
            return;

        // Fade 애니메이션 재생.  
        StartCoroutine("PlayFadeOut");
    }

    public void StartFadeInAnim()
    {
        // 애니메이션이 재생중이면 중복 재생되지 않도록 리턴 처리.  
        if (isPlaying == true)
            return;

        // Fade 애니메이션 재생.  
        StartCoroutine("PlayFadeIn");
    }
}