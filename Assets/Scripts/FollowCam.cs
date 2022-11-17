using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    // ī�޶� �ڱ� �ڽ�
    Transform camTr;

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;

    [Range(0f, 10f)]
    public float height = 2f;

    //���� �ӵ�
    public float damping = 10f;

    void Start()
    {
        camTr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        // ���� ����� �������� distance��ŭ �̵�
        // ���̸� height��ŭ �̵�
        Vector3 pos = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);

        // ���� ���� ���� �Լ��� �ε巴�� ��ġ ����
        camTr.position = Vector3.Slerp(camTr.position, pos, Time.deltaTime * damping);

        camTr.LookAt(targetTr.position);
    }
}
