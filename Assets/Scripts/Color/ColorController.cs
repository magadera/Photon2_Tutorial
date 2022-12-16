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
        //    Debug.Log($"GameObject '{cube.name}'을 찾았습니다.");
        //else
        //    Debug.Log("해당하는 게임 오브젝트 찾지못함.");

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
            Debug.Log("다른 유저가 색을 칠했습니다.");
        }
    }

    void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            cubeRenderer.material.color = myColor;
            Debug.Log("도색 완료");
        }
    }

    void SaveColor()
    {
        if (Input.GetKeyDown("r"))
        {
            myColor = Color.red;
            Debug.Log("red 색 저장");
        }
        if (Input.GetKeyDown("g"))
        {
            myColor = Color.green;
            Debug.Log("green 색 저장");
        }
        if (Input.GetKeyDown("b"))
        {
            myColor = Color.blue;
            Debug.Log("blue 색 저장");
        }

        if (Input.GetKeyDown("m"))
        {
            myColor = Color.magenta;
            Debug.Log("magenta 색 저장");
        }
        if (Input.GetKeyDown("y"))
        {
            myColor = Color.yellow;
            Debug.Log("yellow 색 저장");
        }
        if (Input.GetKeyDown("c"))
        {
            myColor = Color.cyan;
            Debug.Log("cyan 색 저장");
        }

        if (Input.GetKeyDown("w"))
        {
            myColor = Color.white;
            Debug.Log("white 색 저장");
        }
        if (Input.GetKeyDown("k"))
        {
            myColor = Color.black;
            Debug.Log("balck 색 저장");
        }
        if (Input.GetKeyDown("e"))
        {
            myColor = Color.gray;
            Debug.Log("gray 색 저장");
        }
    }
}
