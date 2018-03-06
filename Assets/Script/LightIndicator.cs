using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIndicator : MonoBehaviour
{

	//平行光对象
	public GameObject DirectionLight;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//修改当前对象的方向与平行光对象方向相同
		transform.LookAt(DirectionLight.transform.forward);
	}
}
