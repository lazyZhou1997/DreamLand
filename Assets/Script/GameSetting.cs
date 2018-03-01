using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{


	//背景音量大小的Slider
	public Slider ValueOfVoiceSlider;
	//语音识别开关
	public Toggle VoiceRecognitionToggle;
	//背景音乐
	public AudioSource BackGroudMusic;

	// Use this for initialization
	void Start () {
		//读取当前背景音量并设置
		float valueOfVoice = PlayerPrefs.GetFloat("volume", 0.5f);

		if (valueOfVoice>=0&&valueOfVoice<=1)
		{
			//设置滑动条显示值
			ValueOfVoiceSlider.value = valueOfVoice;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeValueVoice()
	{
		//获取当前滑动条的值
		float valueOfVoice = ValueOfVoiceSlider.value;

		if (valueOfVoice>=0&&valueOfVoice<=1)
		{
			//修改背景音乐的音量
			BackGroudMusic.volume = valueOfVoice;
			//存储当前背景音乐音量
			PlayerPrefs.SetFloat("volume",valueOfVoice);
			Debug.Log(valueOfVoice);
		}

	}
}
