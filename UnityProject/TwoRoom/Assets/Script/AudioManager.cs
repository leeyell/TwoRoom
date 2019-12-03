using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    #region 싱글톤
    private static AudioManager _instance = null;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (AudioManager)FindObjectOfType(typeof(AudioManager));
                if (_instance == null)
                {
                    Debug.Log("There's no active ManagerClass object");
                }
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            DestroyImmediate(gameObject);
        } else
        {
            _instance = this;
        }

        AwakeAfter();
    }
    #endregion

    private float masterVolumeSFX = 1f;
    private float masterVolumeBGM = 1f;

    public AudioClip[] audioClips;  //오디오 소스들 저장
    public Dictionary<string, AudioClip> audioClipDic;

    public AudioSource sfxPlayer;
    public AudioSource bgmPlayer;

    void AwakeAfter()
    {
        sfxPlayer = transform.GetChild(1).GetComponent<AudioSource>();
        bgmPlayer = transform.GetChild(0).GetComponent<AudioSource>();

        audioClipDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in audioClips)
        {
            audioClipDic.Add(a.name, a);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayLoopSound("woodstep1");
        bgmPlayer.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (bgmPlayer.clip == audioClipDic["woodstep1"])
            {
                PlayLoopSound("1. 강한 노크");
            } else
            {
                PlayLoopSound("woodstep1");
            }
            
        }
    }

    // 한 번 재생 : 볼륨 매개변수로 지정
    public void PlaySound(string a_name, float a_volume = 1f)
    {
        if (audioClipDic.ContainsKey(a_name) == false)
        {
            Debug.Log(a_name + " is not Contained audioClipDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipDic[a_name], a_volume * masterVolumeSFX);
    }
    // 랜덤으로 한 번 재생 : 볼륨 매개변수로 지정
    public void PlayRandomSound(string[] a_nameArray, float a_volume = 1f)
    {
        string l_playClipName;

        l_playClipName = a_nameArray[Random.Range(0, a_nameArray.Length)];

        PlaySound(l_playClipName, a_volume);
    }

    // 삭제할 때 리턴값은 GameOjbect를 참조해서 삭제
    // 나중에 옵션에서 사운드 크기 조정하면 이건 같이 참조해서 바뀌어야함 ?
    /*
    public GameObject PlayLoopSound(string a_name)
    {
        if (audioClipDic.ContainsKey(a_name) == false)
        {
            Debug.Log(a_name + "is not Contained audioClipDic");
            return null;
        }
        GameObject l_obj = new GameObject("LoopSound");
        AudioSource source = l_obj.AddComponent<AudioSource>();
        source.volume = masterVolumeSFX;
        source.loop = true;
        source.Play();
        return l_obj;
    }
    */
    public void PlayLoopSound(string a_name)
    {
        bgmPlayer.Stop();
        bgmPlayer.clip = audioClipDic[a_name];
        bgmPlayer.loop = true;
        bgmPlayer.Play();
    }

    // 주로 전투 종료시 음악을 끈다.
    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    #region 옵션에서 볼륨 조절
    public void SetVolumeSFX(float a_volume)
    {
        masterVolumeSFX = a_volume;
    }

    public void SetVolumeBGM(float a_volume)
    {
        masterVolumeBGM = a_volume;
        bgmPlayer.volume = masterVolumeBGM;
    }
    #endregion
}
