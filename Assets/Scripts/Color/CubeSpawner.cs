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

    // 1���� �����ؾ� �ϴϱ� �׳� Start()���� ����.
    void Start()
    {
        // ȣ��Ʈ�� ť�� ����
        // �ٸ� Client���� ȣ��Ʈ�� ������ ť�긦 ����ȭ�� ���� �޾ƿ�

        if (PhotonNetwork.IsMasterClient)
        {
            CreateCube();
        }
    }

    void CreateCube()
    {
        // ť�� ���������� ť�� ����, ��Ʈ��ũ ���� ��� Client�鿡�� ������
        GameObject createdCube = PhotonNetwork.Instantiate(cubePrefab.gameObject.name, cubePrefab.transform.position, cubePrefab.transform.rotation);

        // ������ ť���� �¾��� ���� Cube ������Ʈ ������
        Cube cube = createdCube.GetComponent<Cube>();

        // ������ ť���� �ʱ� Color ����
        cube.photonView.RPC("Setup", RpcTarget.All, Color.yellow);
    }
}
