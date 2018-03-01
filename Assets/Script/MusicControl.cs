using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
	//背景音乐
	public AudioSource BackGroundMusic;

	// Use this for initialization
	void Start () {
		#region 初始化背景音乐的播放

		//获取背景音乐音量
		float valueOfVoice = PlayerPrefs.GetFloat("volume", 0.5f);

		if (valueOfVoice>=0&&valueOfVoice<=1)
		{
			//设置背景音乐音量
			BackGroundMusic.volume = valueOfVoice;
		}

		#endregion
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
