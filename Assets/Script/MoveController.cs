using UnityEngine;

using System.Collections;



public class MoveController : MonoBehaviour
{


	//探测阴影的脚本
	private ShadowDetect _shadowDetect;

	//移动速度
	public int speed;

	//private Rigidbody _rigidbody;

	private void Start()
	{
		_shadowDetect = GetComponent<ShadowDetect>();
	}

	void OnEnable()

	{
		EasyJoystick.On_JoystickMove += OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;

		//_rigidbody = GetComponent<Rigidbody>();
	}





	//移动摇杆结束

	void OnJoystickMoveEnd(MovingJoystick move)

	{

		//停止时，角色恢复idle
		if (move.joystickName == "MoveJoystick")

		{
			Debug.Log("移动停止");
		}

	}





	//移动摇杆中

	void OnJoystickMove(MovingJoystick move)

	{
		if (move.joystickName != "MoveJoystick")

		{
			return;
		}



		//获取摇杆中心偏移的坐标

		float joyPositionX = move.joystickAxis.x;

		float joyPositionY = move.joystickAxis.y;





		if (joyPositionY != 0 || joyPositionX != 0)

		{

			//设置角色的朝向（朝向当前坐标+摇杆偏移量）
			transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));

			//探测前方是否有阴影，如果没有则移动
			if (!_shadowDetect.DetectShadow())
			{
				//移动玩家的位置（按朝向位置移动）
				transform.Translate(Vector3.forward * Time.deltaTime * speed);
			}
			//_rigidbody.velocity = Vector3.forward * Time.deltaTime * speed;

		}

	}

}