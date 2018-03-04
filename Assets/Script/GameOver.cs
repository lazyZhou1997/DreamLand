using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

	//游戏开始的脚本
	public GameBegin _gameBegin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		//获取游戏运行的时间
		float totalTime = _gameBegin.Timer;

		Debug.Log(totalTime);
	}
}
