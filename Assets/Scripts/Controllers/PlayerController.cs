using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseWorldObject
{
	int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);

	PlayerStat _stat;
	bool _stopSkill = false;

	public Transform waist = null;
	bool isOnAutoAim = true;

	public override void Init()
    {
		WorldObjectType = Define.WorldObject.Player;

		_stat = gameObject.GetComponent<PlayerStat>();
		//Managers.Input.MouseAction -= OnMouseEvent;
		//Managers.Input.MouseAction += OnMouseEvent;
		//Managers.Input.KeyAction -= OnKeyBoard;
		//Managers.Input.KeyAction += OnKeyBoard;
		Managers.Input.moveJoystickAction -= OnMoveJoystick;
		Managers.Input.moveJoystickAction += OnMoveJoystick;
		Managers.Input.aimJoystickAction -= OnAimJoystick;
		Managers.Input.aimJoystickAction += OnAimJoystick;

		if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
			Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
		

	}

    private void Update()
    {
		if (isOnAutoAim)
		{

		}
	}
    void OnHitEvent()
	{
        //Ray ray = new Ray()
        //if (_lockTarget != null)
        //{
        //    Stat targetStat = _lockTarget.GetComponent<Stat>();
        //    targetStat.OnAttacked(_stat);
        //}

        //if (_stopSkill)
        //{
        //    State = Define.State.Idle;
        //}
        //else
        //{
        //    State = Define.State.Skill;
        //}
    }


	void OnMoveJoystick(Vector2 axis)
	{
		transform.Translate(new Vector3(axis.x, 0, axis.y) * Time.deltaTime * _stat.MoveSpeed);
	}
	void OnAimJoystick(Vector2 axis)
	{
		
		transform.Rotate(new Vector3(0, axis.x, 0f));

		Vector3 rot = waist.localRotation.eulerAngles;
		rot.z += axis.y;

		if (rot.z < 35f)
			waist.Rotate(new Vector3(0f, 0f, axis.y));
		if (rot.z > -30f + 360f)
			waist.Rotate(new Vector3(0f, 0f, axis.y));
	}
	Vector2 GetAutoAimValue()
    {

		return Vector2.zero;
    }



}
