using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class RotateByTouch : MonoBehaviour {

	//转动速度
	public int Speed;

	protected virtual void OnEnable()
	{
		// Hook events
//		LeanTouch.OnFingerDown += FingerDown;
		LeanTouch.OnFingerSet  += FingerSet;
//		LeanTouch.OnFingerUp   += FingerUp;
	}


	protected virtual void OnDisable()
	{
		// Unhook events
//		LeanTouch.OnFingerDown -= FingerDown;
		LeanTouch.OnFingerSet  -= FingerSet;
//		LeanTouch.OnFingerUp   -= FingerUp;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	/// <summary>
//	/// 指头按下的时候，记录第一个指头的位置
//	/// </summary>
//	/// <param name="obj"></param>
//	private void FingerDown(LeanFinger obj)
//	{
//		_lastFinger = obj;
//	}

	/// <summary>
	/// 当指头保持在屏幕上时，控制TransForm进行旋转
	/// </summary>
	/// <param name="obj"></param>
	private void FingerSet(LeanFinger obj)
	{

		//上一个指头的位置
		Vector2 _lastFingerVector2 = obj.LastScreenPosition;
		//当前指头的位置
		Vector2 _currentFingerVector2 = obj.ScreenPosition;

		//x轴上的位移
		float x = _currentFingerVector2.x - _lastFingerVector2.x;
		//y轴上的位移
		float y = _currentFingerVector2.y - _lastFingerVector2.y;

		float absX = Mathf.Abs(x);
		float absY = Mathf.Abs(y);

		if (absX>absY)
		{
			//绕y轴水平旋转
			transform.Rotate(Vector3.up,x*Speed*Time.deltaTime,Space.World);
		}
		else
		{
			//绕正前方法线向量旋转
			Vector3 orthForward = OrthVector3(transform.forward,Vector3.up);

			transform.Rotate(orthForward,y*Speed*Time.deltaTime,Space.World);
		}

	}

	private Vector3 OrthVector3(Vector3 direction,Vector3 yAixs)
	{
		float a1 = direction.x;
		float b1 = NotZero(direction.y);
		float c1 = NotZero(direction.z);
		float a2 = yAixs.x;
		float b2 = NotZero(yAixs.y);
		float c2 = NotZero(yAixs.z);

		float z = (-a1 * b2 + a2 * b1) / (c1 * b2 - c2 * b1);
		float y = (-c1 * b2 * z - a1 * b2) / b1 * b2;

		return new Vector3(1,y,z);
	}

	/// <summary>
	/// 如果传入的参数为0，则将其值更改为0.001
	/// </summary>
	/// <param name="digit"></param>
	/// <returns></returns>
	private float NotZero(float digit)
	{
		if (0==digit)
		{
			return 0.001f;
		}
		else
		{
			return digit;
		}
	}

//	/// <summary>
//	/// 指头离开屏幕的时候，清空指头记录
//	/// </summary>
//	/// <param name="obj"></param>
//	private void FingerUp(LeanFinger obj)
//	{
//		_lastFinger = null;
//	}
}
