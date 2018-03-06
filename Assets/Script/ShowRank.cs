using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowRank : MonoBehaviour {

	//玩家名称Text列表
	public Text[] NameTexts;
	
	//玩家得分Text列表
	public Text[] ScoreTexts;
	
	//与服务器通信的脚本
	public ServerConnect ServerConnect;
	
	//当前用户的UUID
	private string _UUID;
	
	// Use this for initialization
	void Start () {
		
		//获取用户的UUID
		_UUID = PlayerPrefs.GetString("UUID", null);
		//如果没有已经存在的UUID，生成新的UUID
		if (null == _UUID || "" == _UUID)
		{
			_UUID = Guid.NewGuid().ToString();
			//存储UUID
			PlayerPrefs.SetString("UUID", _UUID);
		}

		//从服务器中获取排名并且显示
		StartCoroutine(ServerConnect.ShowRanklist(NameTexts, ScoreTexts, _UUID));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
