using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

	//游戏开始的脚本
	private GameBegin _gameBegin;

	// Use this for initialization
	void Start () {
		//初始化游戏开始脚本
		_gameBegin = GetComponent<GameBegin>();
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
