using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CameraController : MonoBehaviour
//{
//    [SerializeField]
//    Define.CameraMode _mode = Define.CameraMode.QuarterView;
//    [SerializeField]
//    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

//    [SerializeField]
//    GameObject _player = null;

//    public void SetPlayer(GameObject player) { _player = player; }
//    Transform rotator;

//    void Start()
//    {
//        SetPlayer(transform.root.gameObject);
//        rotator = transform.parent;

//        Managers.Input.aimJoystickAction -= OnAimJoystick;
//        Managers.Input.aimJoystickAction += OnAimJoystick;

  
//    }
//    void OnAimJoystick(Vector2 axis)
//    {
//        rotator.transform.Rotate(new Vector3(0, axis.x, 0f));

//        Vector3 rot = rotator.localRotation.eulerAngles;
//        rot.x += axis.y;

//        if (rot.x < 35f)
//            rotator.Rotate(new Vector3(0f, 0f, rot.y));
//        if (rot.x > -30f + 360f)
//            rotator.Rotate(new Vector3(0f, 0f, rot.y));
//    }
//    void LateUpdate()
//    {
//        if (_player.IsValid() == false)
//        {
//            return;
//        }
//        //rotator.transform.localPosition = _delta;
//        //transform.LookAt(Camera.main.ScreenToWorldPoint(Vector3.zero));
//    }




//}
