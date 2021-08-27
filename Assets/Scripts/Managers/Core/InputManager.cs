using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    public Action<Vector2> moveJoystickAction = null;
    public Action<Vector2> aimJoystickAction = null;


    public VariableJoystick moveJoystick;
    public VariableJoystick aimJoystick;
    //bool _pressed = false;
    //float _pressedTime = 0;

    public void OnUpdate()
    {
        if(moveJoystick != null && moveJoystickAction != null)
        {
            //moveJoystickAction.Invoke(new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical));
            moveJoystickAction.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        if (aimJoystick != null && aimJoystickAction != null)
        {
            aimJoystickAction.Invoke(new Vector2(aimJoystick.Horizontal, aimJoystick.Vertical));
        }
        //if ( && TouchAction != null)
        //    TouchAction.Invoke();

        //if (Input.anyKey && KeyAction != null)
        //KeyAction.Invoke();

        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        //if (MouseAction != null)
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        if (!_pressed)
        //        {
        //            MouseAction.Invoke(Define.MouseEvent.PointerDown);
        //            _pressedTime = Time.time;
        //        }
        //        MouseAction.Invoke(Define.MouseEvent.Press);
        //        _pressed = true;
        //    }
        //    else
        //    {
        //        if (_pressed)
        //        {
        //            if (Time.time < _pressedTime + 0.2f)
        //                MouseAction.Invoke(Define.MouseEvent.Click);
        //            MouseAction.Invoke(Define.MouseEvent.PointerUp);
        //        }
        //        _pressed = false;
        //        _pressedTime = 0;
        //    }
        //}


    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
