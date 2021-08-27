using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WeaponType
    {
        None,
        Shotgun,
        Sniper,
        Bow,
        Bomb,
        Sword,
    }
    public enum EquipmentType
    {
        Weapon,
        Armor,
        Shield,
    }
    public enum joysticRole
    {
        move,
        aim
    }
    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,
    }

	public enum State
	{
		Die,
		Moving,
		Idle,
		Skill,
	}

    public enum Layer
    {
        Monster = 6,
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum TouchEvent
    {
        Down,
        OnDrag,
        Up,
    }
    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }

    public enum CameraMode
    {
        QuarterView,
        TPS,
    }
}
