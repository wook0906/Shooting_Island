using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : WorldObjectBase
{
	int _mask = (1 << (int)Define.Layer.Monster) | 1 << 0;

	Collider[] detectedObjs;

	public Transform cam;
	PlayerStat _stat;
	public PlayerStat Stat
	{
		get { return _stat; }
		set { _stat = value; }
	}
	public Weapon weapon;

	Vector3 dirToLockOnPos;
	
	float moveXAxis;
	float moveZAxis;
	public bool isTargetLockOn = false;
	[HideInInspector] public bool isMoving = false;

	public override void Init()
    {
		WorldObjectType = Define.WorldObject.Player;
		Stat = gameObject.GetOrAddComponent<PlayerStat>();

		Managers.Input.moveJoystickAction -= OnMoveJoystick;
		Managers.Input.moveJoystickAction += OnMoveJoystick;
		
		if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
			Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

		fsm = GetComponent<StateMachine>();
		fsm.Init();
	}

    private void Update()
    {
		LookAtCameraDirection();
		Time.timeScale = Mathf.Lerp(Time.timeScale, Input.GetKey(KeyCode.LeftShift) ? 0.02f : 1, Time.unscaledDeltaTime * 30);

	}
	void OnAttackEvent()
	{
		weapon.Shoot(_mask, cam.GetComponent<ThirdPersonOrbitCamBasic>().lockOnTargetPos);
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
			isMoving = false;
        else
			isMoving = true;
	}
	public Vector2 GetCurrentMoveJoyStickAxis()
    {
		return new Vector2(moveXAxis, moveZAxis);
    }

    
}