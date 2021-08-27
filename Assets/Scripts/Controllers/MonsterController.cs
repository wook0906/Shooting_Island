using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : WorldObjectBase
{
	MonsterStat _stat;
	public MonsterStat Stat
	{
		get { return _stat; }
		set { _stat = value; }
	}

	[SerializeField]
	Vector3 _destPos;

	[SerializeField]
	GameObject _lockTarget;
	public GameObject LockTarget 
	{ 
		get { return _lockTarget; }
        set { _lockTarget = value; }
	}


	[HideInInspector]
	public NavMeshAgent nma;

	public bool IsArrivedToTarget()
    {
		_destPos = _lockTarget.transform.position;
		float distance = (_destPos - transform.position).magnitude;
		if (distance <= Stat.attackRange)
		{
			return true;
		}
		else
			return false;
	}
	public override void Init()
    {
		WorldObjectType = Define.WorldObject.Monster;
		Stat = gameObject.GetOrAddComponent<MonsterStat>();

		nma = gameObject.GetOrAddComponent<NavMeshAgent>();

		if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
			Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

		fsm = GetComponent<StateMachine>();
		fsm.Init();
	}

	//void UpdateIdle()
	//{
	//	GameObject player = Managers.Game.GetPlayer();
	//	if (player == null)
	//		return;

	//	float distance = (player.transform.position - transform.position).magnitude;
	//	if (distance <= _scanRange)
	//	{
	//		_lockTarget = player;
	//		State = Define.State.Moving;
	//		return;
	//	}
	//}

	//void UpdateMoving()
	//{
	//	// 플레이어가 내 사정거리보다 가까우면 공격
	//	if (_lockTarget != null)
	//	{
	//		_destPos = _lockTarget.transform.position;
	//		float distance = (_destPos - transform.position).magnitude;
	//		if (distance <= _attackRange)
	//		{
	//			NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
	//			nma.SetDestination(transform.position);
	//			State = Define.State.Skill;
	//			return;
	//		}
	//	}

	//	// 이동
	//	Vector3 dir = _destPos - transform.position;
	//	if (dir.magnitude < 0.1f)
	//	{
	//		State = Define.State.Idle;
	//	}
	//	else
	//	{
	//		NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
	//		nma.SetDestination(_destPos);
			
	//	}
	//}

	//void UpdateSkill()
	//{
	//	if (_lockTarget != null)
	//	{
	//		Vector3 dir = _lockTarget.transform.position - transform.position;
	//		Quaternion quat = Quaternion.LookRotation(dir);
	//		transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
	//	}
	//}

	void OnHitEvent() //Animation EVent Call
	{
		float distance = (_lockTarget.transform.position - transform.position).magnitude;
		if (distance <= Stat.attackRange)
        {
			Stat targetStat = _lockTarget.GetComponent<Stat>();
			targetStat.OnAttacked(Stat);
		}
    }
	public void SetDestination(Vector3 pos)
    {
		nma.SetDestination(pos);
    }
	public void ResetPath()
	{
		nma.ResetPath();
	}
}
