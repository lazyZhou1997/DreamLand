using UnityEngine;  
using System.Collections;  
  
public class TestRay2 : MonoBehaviour
{
	private Vector3 orgin = new Vector3(0,0,0);  
	private RaycastHit hit;
	
	void Update () {
		for (int i = 0; i < 100; i++)
		{

			// 以摄像机所在位置为起点，创建一条向下发射的射线  
			Ray ray = new Ray(orgin, -Vector3.up); 
		
			if(Physics.Raycast(ray, out hit, Mathf.Infinity))  
			{  
				// 如果射线与平面碰撞，打印碰撞物体信息  
				Debug.Log("碰撞对象: " + hit.collider.name);  
				// 在场景视图中绘制射线  
				Debug.DrawLine(ray.origin, hit.point, Color.red); 
			}
			
			orgin += new Vector3(0,0,1);
		}

	}  
}
