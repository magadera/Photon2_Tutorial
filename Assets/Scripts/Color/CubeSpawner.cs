using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;


public class CubeSpawner : MonoBehaviourPun, IPunObservable
{
    public Cube cubePrefab;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        PhotonPeer.RegisterType(typeof(Color), 128, ColorSerialization.SerializeColor,
            ColorSerialization.DeserializeColor);
    }

    // 1번만 실행해야 하니까 그냥 Start()에서 하자.
    void Start()
    {
        // 호스트만 큐브 생성
        // 다른 Client들은 호스트가 생성한 큐브를 동기화를 통해 받아옴

        if (PhotonNetwork.IsMasterClient)
        {
            CreateCube();
        }
    }

    void CreateCube()
    {
        // 큐브 프리팹으로 큐브 생성, 네트워크 상의 모든 Client들에게 생성됨
        GameObject createdCube = PhotonNetwork.Instantiate(cubePrefab.gameObject.name, cubePrefab.transform.position, cubePrefab.transform.rotation);

        // 생성한 큐브의 셋업을 위해 Cube 컴포넌트 가져옴
        Cube cube = createdCube.GetComponent<Cube>();

        // 생성한 큐브의 초기 Color 설정
        cube.photonView.RPC("Setup", RpcTarget.All, Color.yellow);
    }
}
