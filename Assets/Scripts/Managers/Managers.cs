using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Managers : MonoBehaviourPunCallbacks
{
    // 유일성 보장
    static Managers s_Instance;
    // 유일한 매니저를 가져옴(메서드가 아닌 프로퍼티 사용, 더 편한 사용을 위해)
    static Managers Instance { get { Init(); return s_Instance; } } // 외부에서 접근하기 원하지 않으니 public 삭제

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();

    // 부르고 싶으면 Managers.Input이라는 이름으로 불러오게 될 것
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        Init();
        Debug.Log("매니저s 생존 확인");
    }

    void Update()
    {
        // 키보드나 마우스 체크 등을 Managers 안에서 하기 시작
        _input.OnUpdate();
    }
    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();
        }
    }
}