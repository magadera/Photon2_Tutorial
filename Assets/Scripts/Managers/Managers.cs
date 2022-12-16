using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Managers : MonoBehaviourPunCallbacks
{
    // ���ϼ� ����
    static Managers s_Instance;
    // ������ �Ŵ����� ������(�޼��尡 �ƴ� ������Ƽ ���, �� ���� ����� ����)
    static Managers Instance { get { Init(); return s_Instance; } } // �ܺο��� �����ϱ� ������ ������ public ����

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();

    // �θ��� ������ Managers.Input�̶�� �̸����� �ҷ����� �� ��
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        Init();
        Debug.Log("�Ŵ���s ���� Ȯ��");
    }

    void Update()
    {
        // Ű���峪 ���콺 üũ ���� Managers �ȿ��� �ϱ� ����
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