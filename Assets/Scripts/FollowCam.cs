using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    // 카메라 자기 자신
    Transform camTr;

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;

    [Range(0f, 10f)]
    public float height = 2f;

    //반응 속도
    public float damping = 10f;

    void Start()
    {
        camTr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        // 추적 대상의 뒤쪽으로 distance만큼 이동
        // 높이를 height만큼 이동
        Vector3 pos = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);

        // 구면 선형 보간 함수로 부드럽게 위치 변경
        camTr.position = Vector3.Slerp(camTr.position, pos, Time.deltaTime * damping);

        camTr.LookAt(targetTr.position);
    }
}
