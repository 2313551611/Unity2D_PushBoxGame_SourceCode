using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* 
 * ==============================================================================
 * 功能描述：地图生成
 * 创 建 者：JN_X
 * 创建日期：2019年7月17日
 * ==============================================================================
 */
public class MapGenerator : MonoBehaviour
{
    public IO IO;

    public enum Mode
    {
        Read = 1,
        Create = 2,
        Empty = 3
    }
    public Mode MapMode = Mode.Read;

    public GameObject[] MapBlocks=new GameObject[108];

    public List<string> MapStringList;

    public string ReadMap = "1";

    public GameObject EditPre;
    // Start is called before the first frame update
    void Awake()
    {
        IO = FindObjectOfType<IO>();

        ReadMap = PlayerPrefs.GetString("ReadMap","关卡1");
        if (ReadMap== "0")
        {
            MapMode = Mode.Create;
        }
        else
        {
            MapMode = Mode.Read;
        }
        switch (MapMode)
        {
            case Mode.Read:
                int l = IO.ReadText(ReadMap).Split(' ').Length;
                string[] list = IO.ReadText(ReadMap).Split(' ');
                for (int i = 0; i < l; i++)
                {
                    MapStringList.Add(list[i]);
                }

                MapStringList.Remove("");

                for (int i = 0, j = MapBlocks.Length; i < j; i++)
                {
                    MapBlocks[i].AddComponent<Blocks>();
                    MapBlocks[i].GetComponent<Blocks>().Type = (BlockTypes)int.Parse(MapStringList[i]);
                    MapBlocks[i].GetComponent<Blocks>().Start();
                }
                break;
            case Mode.Create:
                for (int i = 0, j = MapBlocks.Length; i < j; i++)
                {
                    GameObject aa = MapBlocks[i];
                    MapBlocks[i].AddComponent<Blocks>();
                    MapBlocks[i].GetComponent<Blocks>().Type = BlockTypes.Ground;
                    MapBlocks[i].GetComponent<Blocks>().Start();
                    MapBlocks[i].AddComponent<Button>();
                    MapBlocks[i].GetComponent<Button>().onClick.AddListener(() =>
                    Instantiate(EditPre, aa.transform));

                }
                break;
            case Mode.Empty:
                for (int i = 0, j = MapBlocks.Length; i < j; i++)
                {
                    MapBlocks[i].AddComponent<Blocks>();
                    MapBlocks[i].GetComponent<Blocks>().Type = BlockTypes.Air;
                    MapBlocks[i].GetComponent<Blocks>().Start();
                }
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnGUI()
    //{
    //    //保存地图代码
    //    if (GUI.Button(new Rect(0, 0, 100, 100), "save"))
    //    {
    //        Save("关卡1");
    //    }
    //}

    public void Save(InputField inputField)
    {
        string Name = inputField.text;
        string a = "";
        for(int i = 0; i < 108; i++)
        {
            int v = (int)MapBlocks[i].GetComponent<Blocks>().Type;
            a += v.ToString()+" ";
        }

        Chest[] Chests = FindObjectsOfType<Chest>();
        for(int i = 0, j = Chests.Length; i < j; i++)
        {
            string x = Chests[i].transform.position.x.ToString();
            string y = Chests[i].transform.position.y.ToString();

            a += x+","+y +" ";
        }

        IO.Write(Name, a);
    }
}

