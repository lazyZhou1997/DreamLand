using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDirectionController : MonoBehaviour {

	//AR相机位置
	public Transform m_Cam;//主摄像机位置

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//获取主摄像机
		m_Cam = Camera.main.transform;
		//获取摄像机的正前方
		Vector3 m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1));
		//设置角色一直面向摄像机正前方
		transform.LookAt(new Vector3(transform.position.x + m_CamForward.x, transform.position.y, transform.position.z + m_CamForward.z));
		Debug.Log(m_CamForward);

	}
}
