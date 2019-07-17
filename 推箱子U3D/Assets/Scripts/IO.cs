using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 * ==============================================================================
 * 功能描述：数据流的写入与输出 
 * 创 建 者：JN_X
 * 创建日期：2019年7月17日
 * ==============================================================================
 */
public class IO : MonoBehaviour
{
    public string path;//数据路径
    // Start is called before the first frame update
    public void Start()
    {
        //如果没存档的话创造存档
        Write("关卡1", "1 1 1 1 1 1 1 1 1 1 1 1 1 2 2 2 2 2 2 1 1 3 1 1 1 2 2 2 2 2 2 1 1 2 1 1 1 2 2 2 1 2 2 1 1 2 1 1 1 2 1 2 1 2 2 1 1 2 1 1 1 3 1 2 1 2 2 1 1 2 1 1 1 1 1 2 2 2 2 2 2 2 2 1 1 1 1 2 2 1 1 1 2 2 2 1 1 1 1 1 1 1 1 1 1 1 1 1 297,341.333 681,212 ");
        Write("关卡2", "1 1 1 1 1 1 1 1 1 1 1 1 1 2 2 2 2 2 2 1 2 2 2 1 1 2 2 2 2 2 2 1 2 2 2 1 1 2 1 2 1 2 2 1 3 2 2 1 1 2 1 2 1 2 2 1 1 2 2 1 1 3 1 2 1 2 2 1 1 2 1 1 1 1 2 2 2 2 2 2 2 2 2 1 1 3 2 2 2 2 2 2 2 2 2 1 1 1 1 1 1 1 1 1 1 1 1 1 811,474 388,211 214,559.33 -214,559.33");
        Write("0", "");
        //刷新
        if (PlayerPrefs.GetInt("New")==0)
        {
            PlayerPrefs.SetString("ReadMap", "关卡1");
            PlayerPrefs.SetInt("New", 1);
            Application.LoadLevel(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR//编辑器下方便调试
        if (Input.GetKey(KeyCode.X))
        {
            PlayerPrefs.DeleteAll();//删除本地数据
        }
#endif
    }

    void FindFile(string MapName)//加载以及创建文件
    {
#if PLATFORM_STANDALONE
        path = Application.dataPath + "/StreamingAssets";
#elif PLATFORM_IOS
         path = Application.dataPath + "/Raw";
#elif PLATFORM_ANDROID
         path = "jar:file://" + Application.dataPath + "!/assets/";
#endif
        if (!Directory.Exists(path + "/Map"))
        {
            Directory.CreateDirectory(path + "/Map");
        }


        if (!File.Exists(path + "/Map/" + MapName + ".txt"))
        {
            FileStream fs = new FileStream(path + "/Map/" + MapName + ".txt",FileMode.Create);
            fs.Close();
        }
    }

    public void Write(string MapName,string Text)//写入文件
    {

        FindFile(MapName);

        File.WriteAllText(path + "/Map/" + MapName + ".txt",Text);
    }

   public static string ReadText(string MapName)//读取文件
    {
        string path;
#if PLATFORM_STANDALONE
        path = Application.dataPath + "/StreamingAssets";
#elif PLATFORM_IOS
         path = Application.dataPath + "/Raw";
#elif PLATFORM_ANDROID
         path = "jar:file://" + Application.dataPath + "!/assets/";
#endif
        StreamReader sr = new StreamReader(path + "/Map/" + MapName + ".txt");
        string value= sr.ReadToEnd();
        sr.Close();
        return value;
    }

    public static string[] GetMaps()//获取所有地图文件
    {
        string path;
#if PLATFORM_STANDALONE
        path = Application.dataPath + "/StreamingAssets";
#elif PLATFORM_IOS
         path = Application.dataPath + "/Raw";
#elif PLATFORM_ANDROID
         path = "jar:file://" + Application.dataPath + "!/assets/";
#endif
        DirectoryInfo di = new DirectoryInfo(path + "/Map");
        string[] ls = new string[di.GetFiles("*.txt").Length];
        FileInfo[] fs = di.GetFiles("*.txt");

        for (int i = 0, j = ls.Length; i < j; i++)
        {
            ls[i] = fs[i].Name.Replace(".txt","");
        }

        return ls;
    }

    public static int MapCounts()//获取地图总数
    {
        string path;
#if PLATFORM_STANDALONE
        path = Application.dataPath + "/StreamingAssets";
#elif PLATFORM_IOS
         path = Application.dataPath + "/Raw";
#elif PLATFORM_ANDROID
         path = "jar:file://" + Application.dataPath + "!/assets/";
#endif
        DirectoryInfo di = new DirectoryInfo(path+"/Map");
        int value= di.GetFiles("*.txt").Length;
        return (value);
    }
}
