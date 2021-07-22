using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region prev
    //[SerializeField]
    //Define.CameraMode _mode = Define.CameraMode.QuarterView;
    //[SerializeField]
    //Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    //[SerializeField]
    //GameObject _player = null;

    //public void SetPlayer(GameObject player) { _player = player; }

    //void Start()
    //{
    //    switch (_mode)
    //    {
    //        case Define.CameraMode.QuarterView:
    //            break;
    //        case Define.CameraMode.TPS:
    //            transform.SetParent(_player.transform);
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //void LateUpdate()
    //{
    //    switch (_mode)
    //    {
    //        case Define.CameraMode.QuarterView:
    //            if (_player.IsValid() == false)
    //            {
    //                return;
    //            }

    //            RaycastHit hit;
    //            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, 1 << (int)Define.Layer.Block))
    //            {
    //                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
    //                transform.position = _player.transform.position + _delta.normalized * dist;
    //            }
    //            else
    //            {
    //                transform.position = _player.transform.position + _delta;
    //                transform.LookAt(_player.transform);
    //            }
    //            break;
    //        case Define.CameraMode.TPS:
    //            if (_player.IsValid() == false)
    //            {
    //                return;
    //            }
    //            transform.localPosition = _delta;
    //            //transform.LookAt(Camera.main.ScreenToWorldPoint(Vector3.zero));

    //            break;
    //        default:
    //            break;
    //    }
    //}

    //public void SetQuarterView(Vector3 delta)
    //{
    //    _mode = Define.CameraMode.QuarterView;
    //    _delta = delta;
    //}
    #endregion

    float detectDistanceFromAim;
    Vector2 aimPos;

    private void Start()
    {
        Vector3 targetScreenPos = Camera.main.WorldToViewportPoint(GameObject.Find("Tent").transform.position);
        Vector3 aimPos = Camera.main.ScreenToViewportPoint(GameObject.Find("Crosshair").transform.position);
        Debug.Log(aimPos);
        Debug.Log(targetScreenPos);
    }
    private void Update()
    {
        
    }
}
