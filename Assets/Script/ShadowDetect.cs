using UnityEngine;

public class ShadowDetect : MonoBehaviour
{
	//平行光的位置信息
	public Transform LightTransform;
	//射线发起的位置
	public Transform[] RayTransform;

	//平行光的照射方向
	private Vector3 _lightDirection;


	// Update is called once per frame
	void Update () {
		
	}

	public bool DetectShadow()
	{
		//获取平行光的照射方向
		_lightDirection = LightTransform.forward;
		Vector3 orgin;
		Ray ray;
		//发射射线，进行碰撞检测
		foreach (Transform rayTransform in RayTransform)
		{
			//射线起点获取
			orgin = rayTransform.position;
			//发射射线
			ray = new Ray(orgin, -_lightDirection);
//			Debug.Log(light_Direction);
//			Debug.Log(-light_Direction);
//			Debug.DrawLine(ray.origin,ray.GetPoint(10),Color.red);
			//设置射线只检测"terrain"层
			int layer = LayerMask.NameToLayer("ignore");
			//碰撞信息，用于调试
			
			RaycastHit raycastHit;
			Debug.Log("reach");
			if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity,~(1<<layer)))
			{
//				// 如果射线与平面碰撞，打印碰撞物体信息
//				Debug.Log("碰撞对象: " + raycastHit.collider.name);
//				// 在场景视图中绘制射线
//				Debug.DrawLine(ray.origin, raycastHit.point, Color.red);
				//发生碰撞，有阴影
				Debug.Log("阴影");
				return true;
			}
		}

		//没有发生碰撞，无阴影
		return false;
	}
}
