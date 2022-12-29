using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Drawing;
using ExitGames.Client.Photon;
using Color = UnityEngine.Color;
//using Photon.Pun.Demo.PunBasics;

public class Cube : MonoBehaviourPun
{
    //GameObject cube;
    //Color myColor;
    //Color receiveColor;

    public Color color { get; set; }    // 현재 컬러
    private Renderer cubeRenderer;
    //TextMeshProUGUI myColorText = null;

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(myColor);
    //    }
    //    else
    //    {
    //        receiveColor = (Color)stream.ReceiveNext();
    //    }
    //}

    private void Awake()
    {
        cubeRenderer = this.GetComponent<Renderer>();
    }

    [PunRPC]
    public void Setup(Color cubeColor)
    {
        cubeRenderer.material.color = cubeColor;
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
        SaveColor();
        if (PhotonNetwork.IsMasterClient)
        {
            ChangeColor();
        }
    }

    [PunRPC]
    public void ApplyUpdatedColor(Color newColor)
    {
        cubeRenderer.material.color = newColor;
    }

    [PunRPC]
    public void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            photonView.RPC("ApplyUpdatedColor", RpcTarget.All, color);
        }
    }

    [PunRPC]
    public void SaveColor()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown("r"))
            {
                color = Color.red;
                Debug.Log("red 색 저장");
            }
            if (Input.GetKeyDown("g"))
            {
                photonView.RPC("ApplyUpdatedColor", RpcTarget.All, Color.green);
                Debug.Log("green 색 저장");
            }
            if (Input.GetKeyDown("b"))
            {
                photonView.RPC("ApplyUpdatedColor", RpcTarget.All, Color.blue);
                Debug.Log("blue 색 저장");
            }

            if (Input.GetKeyDown("m"))
            {
                photonView.RPC("ApplyUpdatedColor", RpcTarget.All, Color.magenta);
                Debug.Log("magenta 색 저장");
            }
            if (Input.GetKeyDown("y"))
            {
                photonView.RPC("ApplyUpdatedColor", RpcTarget.All, Color.yellow);
                Debug.Log("yellow 색 저장");
            }
            if (Input.GetKeyDown("c"))
            {
                photonView.RPC("ApplyUpdatedColor", RpcTarget.All, Color.cyan);
                Debug.Log("cyan 색 저장");
            }

            //if (Input.GetKeyDown("w"))
            //{
            //    photonView.RPC("ApplyUpdatedColor", RpcTarget.All, Color.white);
            //    Debug.Log("white 색 저장");
            //}
            if (Input.GetKeyDown("k"))
            {
                photonView.RPC("ApplyUpdatedColor", RpcTarget.All, Color.black);
                Debug.Log("balck 색 저장");
            }
            if (Input.GetKeyDown("e"))
            {
                photonView.RPC("ApplyUpdatedColor", RpcTarget.All, Color.gray);
                Debug.Log("gray 색 저장");
            }
        }
        
    }
}
