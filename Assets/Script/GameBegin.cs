using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBegin : MonoBehaviour
{

	//计时器，统计游戏进行的时间
	private float _timer;

	//显示当前时间的Text
	public Text ShowTimeText;

	/// <summary>
	/// 获取当前游戏已经经过的时间
	/// </summary>
	public float Timer
	{
		get { return _timer; }
	}

	//开始计时标志
	private bool _beginGame;

	// Use this for initialization
	void Start () {

		//初始化，游戏没有开始
		_beginGame = false;
		//计时初始化
		_timer = 0;
	}

	private void Update()
	{
		//如果游戏已经开始
		if (_beginGame)
		{
			//计算已经经过的时间
			_timer += Time.deltaTime;
			
			//将经过时间显示到屏幕上
			ShowTimeText.text = Convert.ToString((int) _timer / 60) +
			                ":" +
			                Convert.ToString((int) _timer % 60);
		}
	}

	/// <summary>
	/// 离开起点，设置标志开始游戏
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerExit(Collider other)
	{
		//开始进行游戏
		_beginGame = true;
		Debug.Log("开始");
	}


}
