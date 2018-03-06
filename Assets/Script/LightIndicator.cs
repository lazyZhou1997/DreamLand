using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIndicator : MonoBehaviour
{

	//平行光对象
	public GameObject DirectionLight;
	
	
	// Update is called once per frame
	void Update () {
		
		//光线方向
		Vector3 direction = DirectionLight.transform.forward;
		
		//修改当前对象的方向与平行光对象方向相同
		transform.LookAt(new Vector3(transform.position.x + direction.x, transform.position.y+direction.y, transform.position.z + direction.z));
		
	}
}
