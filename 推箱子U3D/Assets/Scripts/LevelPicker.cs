using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* 
 * ==============================================================================
 * 功能描述：关卡选择器
 * 创 建 者：JN_X
 * 创建日期：2019年7月17日
 * ==============================================================================
 */
public class LevelPicker : MonoBehaviour
{
    public GameObject ChestPre;
    public GameObject Chest;

    public Dropdown Dropdown;

    public string value;
    // Start is called before the first frame update
    public void Start()
    {
        Dropdown.ClearOptions();
        string[] vs = IO.GetMaps();
        List<string> ls = new List<string>();
        for(int i = 0; i < vs.Length; i++)
        {
            if (vs[i] !="0")
            {
                ls.Add(vs[i]);
            }
            else
            {
                ls.Add("关卡编辑器");
            }
        }
        Dropdown.AddOptions(ls);

        Dropdown.onValueChanged.AddListener(ChangeMap);
        for (int i = 0, j = Dropdown.options.Capacity; i < j; i++)
        {
            if (Dropdown.options[i].text == PlayerPrefs.GetString("ReadMap"))
            {
                Dropdown.value = i;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        value= Dropdown.options[Dropdown.value].text;
        if (value != "关卡编辑器")
        {
            PlayerPrefs.SetString("ReadMap", value);
            ChestPre.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetString("ReadMap","0");
            ChestPre.SetActive(true);
        }
    }

    public void ChangeMap(int value)
    {
        string a = IO.GetMaps()[value];
        if (a != PlayerPrefs.GetString("ReadMap"))
        {
            PlayerPrefs.SetString("ReadMap", a);
            Application.LoadLevel(0);
        }


    }

    public void Create()
    {
        Instantiate(Chest,GameObject.Find("Canvas").transform);
    }
}
