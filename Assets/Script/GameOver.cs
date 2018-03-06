using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //显示最终的游戏时间
    public Text ShowFinalGameTimeText;

    //游戏结束画面
    public GameObject Panel;

    //控制盘
    public GameObject MoveJoystick;

    //星级评定时间
    public float FirstLevel; //三星

    public float SecondLevel; //两星
    public float ThirdLevel; //一星

    //星级图片
    public GameObject Star1;

    public GameObject Star2;
    public GameObject Star3;

    //游戏开始的脚本
    public GameBegin _gameBegin;

    //与服务器通信脚本
    public ServerConnect ServerConnect;

    //当前用户的UUID
    private string _UUID;

    //用户昵称
    private string _nickname = "匿名";

    // Use this for initialization
    void Start()
    {
        //获取用户的UUID
        _UUID = PlayerPrefs.GetString("UUID", null);
        //如果没有已经存在的UUID，生成新的UUID
        if (null == _UUID || "" == _UUID)
        {
            _UUID = Guid.NewGuid().ToString();
            //存储UUID
            PlayerPrefs.SetString("UUID", _UUID);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// 当接触终点的时候，设置游戏结束
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //设置游戏结束
        _gameBegin.BeginGame = false;

        //获取游戏运行的时间
        float totalTime = _gameBegin.Timer;

        //显示游戏结束画面
        Panel.SetActive(true);

        //取消控制盘显示
        MoveJoystick.SetActive(false);

        //显示游戏耗时
        ShowFinalGameTimeText.text = Convert.ToString((int) totalTime / 60) +
                                     ":" +
                                     Convert.ToString((int) totalTime % 60);

        //显示星级
        if (totalTime <= FirstLevel) //三星
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
        else if (totalTime > FirstLevel && totalTime <= SecondLevel) //两星
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
        }
        else if (totalTime > SecondLevel && totalTime <= ThirdLevel) //一星
        {
            Star1.SetActive(true);
        }

        //计算游戏得分
        int score = (int)(1 / totalTime) * 20000;

        //上传游戏数据
        StartCoroutine(ServerConnect.UploadInfo(_UUID, score, _nickname));
    }
}