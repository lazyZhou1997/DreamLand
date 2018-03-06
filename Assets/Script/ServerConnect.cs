using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerConnect : MonoBehaviour
{

    //当前用户的UUID
    private string _UUID;
    
    // 可以选择从配置文件中获取
    private string ServerUrl = "https://dreamland-test.azurewebsites.net/ScoreServlet";

    /**
     * 上传分数 / 修改昵称
     * 上传分数: UploadInfo("UUID", 10.0, "nickname");
     * 修改昵称: UploadInfo("UUID", 0.0, "newname");
     * 
     * UUID:      由设备生成的uuid, 一台设备应当只有一个uuid。
     *            即第一次生成的uuid应当保存至文件中。
     * score:     最后玩家得分
     * nickname:  玩家昵称，不能为空
     */
    IEnumerator UploadInfo(string uuid, double score, string nickname)
    {
        // uuid不能为空
        if (uuid == null || uuid == "")
        {
            throw new NullReferenceException("UUID should not be null");
        }

        // nickname不能为空
        if (nickname == null || nickname == "")
        {
            throw new NullReferenceException("Name should not be null");
        }

        string userJson = JsonUtility.ToJson(new User(uuid, score, nickname));

        using (UnityWebRequest request = UnityWebRequest.Put(ServerUrl, userJson))
        {
            // 使用PUT方法避免Unity进行Base64编码
            // 然后变更为POST方法匹配API
            request.method = UnityWebRequest.kHttpVerbPOST;
            yield return request.SendWebRequest();

            // 服务器返回的排名为字符串
            string rankString = request.downloadHandler.text;

            // TODO: 服务器异常处理，在界面上显示网络异常
            long rank = long.Parse(rankString);

            // TODO: 在界面中显示排名
            Debug.Log(rank);
        }
    }

    /**
     * 返回排行榜
     */
    IEnumerator ShowRanklist()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(ServerUrl))
        {
            yield return request.SendWebRequest();
            string ranklistJson = request.downloadHandler.text;

            // JsonUtility 无法识别JSON数组，因此补全为JSON对象
            // TODO: 此处可能产生异常，在界面上显示网络异常
            List<User> RankList = JsonUtility.FromJson<UserList>("{\"Users\":"+ranklistJson+"}").Users;

            // TODO: 在界面中显示排行榜
            Debug.Log(RankList[0].UUID);
        }
    }

    // Use this for initialization
    void Start ()
    {
        //获取用户的UUID
        _UUID = PlayerPrefs.GetString("UUID",null);
        //如果没有已经存在的UUID，生成新的UUID
        if (null == _UUID)
        {
            _UUID = Guid.NewGuid().ToString();
            //存储UUID
            PlayerPrefs.SetString("UUID",_UUID);
        }
        
    }
	
	// Update is called once per frame
	void Update ()
	{
	    
	}
}

[System.Serializable]
public class UserList
{
    public List<User> Users;
}

[System.Serializable]
public class User
{

    public string UUID;
    public double score;
    public string name;

    public User(string uuid, double score, string name)
    {
        this.UUID = uuid;
        this.score = score;
        this.name = name;
    }
}