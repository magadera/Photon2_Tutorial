using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    //public Action<Define.MouseEvent> MouseAction = null;

    //bool _pressed = false;

    // Update()에서 이름을 수정한 이유는 MonoBehaviour 상속하지 않고 누군가가 직접 불러주는 거니까.
    // 체크는 이제 유일하게 여기서 합니다. PlayerController가 100개든 1000개든~
    // 루프마다 1번씩만 체크해서 이벤트 전파
    // 또 다른 장점은 모든 로직 PlayerController의 Update()에 때려박았다면 너무 많아졌을 때 뭐가 어디서 호출됐는지 구분이 안감
    // 이벤트 방식으로 처리하면 brakePoint 잡아서 쉽게 원인 파악 가능
    public void OnUpdate()
    {
        // 키 입력이 없으면 종료
        // 그게 아니면(키 입력이 있으면) 이벤트 전파
        // 이벤트 듣고 싶다고 구독한 사람은 전달받음
        if (Input.anyKey == false)
            return;
        if (KeyAction != null)
        {
            KeyAction.Invoke();
        }
    }

    //public void OnUpdate()
    //{
    //    if(MouseAction != null)
    //    {
    //        if (Input.GetMouseButton(0))
    //        {
    //            MouseAction.Invoke(Define.MouseEvent.Press);
    //            // 누르면 상태 기억했다가
    //            _pressed = true;
    //        }
    //        else
    //        {
    //            // 그 상태에서 떼면 클릭으로 인정
    //            if (_pressed)
    //            {
    //                MouseAction.Invoke(Define.MouseEvent.Click);
    //                _pressed = false;
    //            }
    //        }
    //    }
    //}
}
