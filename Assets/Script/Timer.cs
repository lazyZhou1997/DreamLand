using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	//统计总共经历的时间
	private float totalTime;

	//此场景最大运行时间
	private const int MAX_TIME = 25;
	//下一个场景的名称
	private const string NEXT_SCENE_NAME = "game1";

	// Use this for initialization
	void Start ()
	{
		//初始化
		totalTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//更新场景经历的时间
		totalTime += Time.deltaTime;
		//如果经历时间大于指定值，则跳转到指定场景
		if (totalTime>MAX_TIME)
		{
			SceneManager.LoadScene(NEXT_SCENE_NAME);
		}
	}


}
