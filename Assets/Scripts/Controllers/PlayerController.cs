using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseWorldObject
{
	int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);

	PlayerStat _stat;
	public PlayerStat Stat
    {
        get { return _stat; }
    }
	bool _stopSkill = false;

	Collider[] detectedObjs;
	LayerMask scanLayer = 1 << 8;

	public Transform cam;

	StateMachine fsm;
	float moveXAxis;
	float moveZAxis;

	public override void Init()
    {
		WorldObjectType = Define.WorldObject.Player;
		_stat = gameObject.GetComponent<PlayerStat>();
		
		Managers.Input.moveJoystickAction -= OnMoveJoystick;
		Managers.Input.moveJoystickAction += OnMoveJoystick;
		

		if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
			Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

		fsm = GetComponent<StateMachine>();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			OnHitEvent();
        }
		LookAtCameraDirection();
	}
    void OnHitEvent()
	{
		//Ray ray = Camera.main.ScreenPointToRay(aimPos);
		//RaycastHit hit;
		//if(Physics.Raycast(ray,out hit,scanLayer))
  //      {
		//	hit.transform.GetComponent<Stat>().OnAttacked(_stat);
  //      }
    }

	void LookAtCameraDirection()
    {
		Quaternion newRot = Quaternion.LookRotation(cam.forward, Vector3.up);
		newRot.x = 0f;
		newRot.z = 0f;
		transform.rotation = newRot;
    }
	void OnMoveJoystick(Vector2 axis)
	{
		moveXAxis = axis.x;
		moveZAxis = axis.y;

		if(axis == Vector2.zero)
			fsm.isMoving = false;
        else
			fsm.isMoving = true;
	}
	public Vector2 GetCurrentMoveJoyStickAxis()
    {
		return new Vector2(moveXAxis, moveZAxis);
    }
	



}
