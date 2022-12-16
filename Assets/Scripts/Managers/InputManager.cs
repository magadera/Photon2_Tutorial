using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    //public Action<Define.MouseEvent> MouseAction = null;

    //bool _pressed = false;

    // Update()���� �̸��� ������ ������ MonoBehaviour ������� �ʰ� �������� ���� �ҷ��ִ� �Ŵϱ�.
    // üũ�� ���� �����ϰ� ���⼭ �մϴ�. PlayerController�� 100���� 1000����~
    // �������� 1������ üũ�ؼ� �̺�Ʈ ����
    // �� �ٸ� ������ ��� ���� PlayerController�� Update()�� �����ھҴٸ� �ʹ� �������� �� ���� ��� ȣ��ƴ��� ������ �Ȱ�
    // �̺�Ʈ ������� ó���ϸ� brakePoint ��Ƽ� ���� ���� �ľ� ����
    public void OnUpdate()
    {
        // Ű �Է��� ������ ����
        // �װ� �ƴϸ�(Ű �Է��� ������) �̺�Ʈ ����
        // �̺�Ʈ ��� �ʹٰ� ������ ����� ���޹���
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
    //            // ������ ���� ����ߴٰ�
    //            _pressed = true;
    //        }
    //        else
    //        {
    //            // �� ���¿��� ���� Ŭ������ ����
    //            if (_pressed)
    //            {
    //                MouseAction.Invoke(Define.MouseEvent.Click);
    //                _pressed = false;
    //            }
    //        }
    //    }
    //}
}
