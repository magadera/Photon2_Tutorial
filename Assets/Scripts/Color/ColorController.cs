using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class ColorController : MonoBehaviourPunCallbacks, IPunObservable
{
    //GameObject cube;
    Color myColor;
    Color receiveColor;
    public Renderer cubeRenderer;
    //TextMeshProUGUI myColorText = null;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(myColor);
        }
        else
        {
            receiveColor = (Color)stream.ReceiveNext();
        }
    }

    private void Awake()
    {
        cubeRenderer = this.GetComponent<Renderer>();
    }

    void Start()
    {
        //cube = GameObject.FindGameObjectWithTag("Cube");
        //if (cube != null)
        //    Debug.Log($"GameObject '{cube.name}'�� ã�ҽ��ϴ�.");
        //else
        //    Debug.Log("�ش��ϴ� ���� ������Ʈ ã������.");

        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;

        //myColorText = TextManager.instance.textMeshProUGUI;
        //Debug.Log(myColorText.text);
        //myColorText.text = myColor.ToString();
    }

    void OnKeyboard()
    {
        if (photonView.IsMine)
        {
            ChangeColor();
            SaveColor();
        }
        else
        {
            cubeRenderer.material.color = receiveColor;
            Debug.Log("�ٸ� ������ ���� ĥ�߽��ϴ�.");
        }
    }

    void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            cubeRenderer.material.color = myColor;
            Debug.Log("���� �Ϸ�");
        }
    }

    void SaveColor()
    {
        if (Input.GetKeyDown("r"))
        {
            myColor = Color.red;
            Debug.Log("red �� ����");
        }
        if (Input.GetKeyDown("g"))
        {
            myColor = Color.green;
            Debug.Log("green �� ����");
        }
        if (Input.GetKeyDown("b"))
        {
            myColor = Color.blue;
            Debug.Log("blue �� ����");
        }

        if (Input.GetKeyDown("m"))
        {
            myColor = Color.magenta;
            Debug.Log("magenta �� ����");
        }
        if (Input.GetKeyDown("y"))
        {
            myColor = Color.yellow;
            Debug.Log("yellow �� ����");
        }
        if (Input.GetKeyDown("c"))
        {
            myColor = Color.cyan;
            Debug.Log("cyan �� ����");
        }

        if (Input.GetKeyDown("w"))
        {
            myColor = Color.white;
            Debug.Log("white �� ����");
        }
        if (Input.GetKeyDown("k"))
        {
            myColor = Color.black;
            Debug.Log("balck �� ����");
        }
        if (Input.GetKeyDown("e"))
        {
            myColor = Color.gray;
            Debug.Log("gray �� ����");
        }
    }
}
