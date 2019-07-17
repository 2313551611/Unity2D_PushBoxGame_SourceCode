using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//方块Type
public enum BlockTypes
{
    Air=0,
    Wall=1,
    Ground=2,
    Point=3
}
/* 
 * ==============================================================================
 * 功能描述：方块类 
 * 创 建 者：JN_X
 * 创建日期：2019年7月17日
 * ==============================================================================
 */
public class Blocks : MonoBehaviour
{
    public BlockTypes Type = BlockTypes.Air;

    public Image Image;
    // Start is called before the first frame update
    public void Start()
    {
        Image = this.GetComponent<Image>();

        switch (Type)//通过方块类型切换图片以及部分组件
        {
            case BlockTypes.Air:
                Image.sprite = null;
                Image.enabled = false;
                break;
            case BlockTypes.Wall:
                Image.sprite = Resources.Load<Sprite>("wall");
                Image.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                break;
            case BlockTypes.Ground:
                Image.sprite = Resources.Load<Sprite>("ground");
                Image.gameObject.tag = "Ground";
                break;
            case BlockTypes.Point:
                Image.sprite = Resources.Load<Sprite>("point");
                Image.gameObject.tag = "Point";
                Image.GetComponent<BoxCollider2D>().size = new Vector2(50, 50);
                break;
            default:
                Image.sprite = null;
                Image.enabled = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (Type)//每一帧执行一次检查方块
        {
            case BlockTypes.Air:
                Image.sprite = null;
                Image.enabled = false;
                break;
            case BlockTypes.Wall:
                Image.sprite = Resources.Load<Sprite>("wall");
                Image.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                break;
            case BlockTypes.Ground:
                Image.sprite = Resources.Load<Sprite>("ground");
                Image.gameObject.tag = "Ground";
                break;
            case BlockTypes.Point:
                Image.sprite = Resources.Load<Sprite>("point");
                Image.gameObject.tag = "Point";
                Image.GetComponent<BoxCollider2D>().size = new Vector2(50, 50);
                break;
            default:
                Image.sprite = null;
                Image.enabled = false;
                break;
        }
    }
}
