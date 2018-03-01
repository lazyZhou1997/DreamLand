using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightController : MonoBehaviour
{

	public int speed;

	void OnEnable()

	{
		EasyJoystick.On_JoystickMove += OnJoystickMove;

		//_rigidbody = GetComponent<Rigidbody>();
	}



	//移动摇杆中

	void OnJoystickMove(MovingJoystick move)

	{
		if (move.joystickName != "ChangeLightDirection")

		{
			return;
		}

		//获取摇杆中心偏移的坐标

		float joyPositionX = move.joystickAxis.x;

		float joyPositionY = move.joystickAxis.y;

		float AbsjoyPositionX = Mathf.Abs(joyPositionX);

		float AbsjoyPositionY = Mathf.Abs(joyPositionY);


		if (joyPositionY != 0 || joyPositionX != 0)
		{

			//设置角色的朝向（朝向当前坐标+摇杆偏移量）
			//transform.LookAt(new Vector3(transform.forward.x + joyPositionX, transform.forward.y, transform.forward.z + joyPositionY));


			//决定绕哪个方向旋转
			if (AbsjoyPositionX<AbsjoyPositionY)
			{
				//绕z轴旋转
				if (joyPositionY>0)
				{
					transform.Rotate(Vector3.fwd,speed*Time.deltaTime,Space.World);
				}
				else
				{
					transform.Rotate(Vector3.fwd,-speed*Time.deltaTime,Space.World);
					Debug.Log("reach1");
				}

			}
			else
			{
				if (joyPositionX>0)
				{
					transform.Rotate(Vector3.up,speed*Time.deltaTime,Space.World);
				}
				else
				{
					transform.Rotate(Vector3.up,-speed*Time.deltaTime,Space.World);
				}
			}

		}

	}
}
