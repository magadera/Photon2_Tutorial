using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ColorLauncher : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";
    bool isConnecting;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
