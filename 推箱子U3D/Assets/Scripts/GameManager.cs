using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 * ==============================================================================
 * 功能描述：游戏管理类
 * 创 建 者：JN_X
 * 创建日期：2019年7月17日
 * ==============================================================================
 */
public class GameManager : MonoBehaviour
{
    public MapGenerator MapGenerator;

    public GameObject ChestPre;
    public GameObject Pass;

    public List<Chest> Chests;
    public List<string> ChestPos;

    public bool IsALlClear;
    // Start is called before the first frame update
    void Start()
    {
        //生成箱子
        for (int i = 108, j = MapGenerator.MapStringList.Count; i < j; i++)
        {
            ChestPos.Add(MapGenerator.MapStringList[i]);
        }

        for(int i = 0, j = ChestPos.Count; i < j; i++)
        {
            string[] ls = ChestPos[i].Split(',');
            Instantiate(ChestPre, new Vector3(float.Parse(ls[0]), float.Parse(ls[1])),Quaternion.identity,GameObject.Find("Canvas").transform);
        }

        var list = FindObjectsOfType<Chest>();
        for (int i = 0, j = FindObjectsOfType<Chest>().Length; i < j; i++)
        {
            Chests.Add(list[i]);
        }

        IsALlClear = false;

    }

    // Update is called once per frame
    void Update()
    {
        bool Judge = true;
        for (int i = 0, j = FindObjectsOfType<Chest>().Length; i < j; i++)
        {
            if (!Chests[i].IsOnPoint)
            {
                Judge = false;
            }
        }
        if (Judge)
        {
            IsALlClear = true;
            Pass.SetActive(true);
            this.enabled = false;
        }
    }

}
