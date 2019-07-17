using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* 
 * ==============================================================================
 * 功能描述：方块编辑器
 * 创 建 者：JN_X
 * 创建日期：2019年7月17日
 * ==============================================================================
 */
public class EditBlock : MonoBehaviour
{
    public Blocks Block;

    public Dropdown Dropdown;
    // Start is called before the first frame update
    void Start()
    {
        Block = GetComponentInParent<Blocks>();
        Dropdown = this.GetComponent<Dropdown>();

        Dropdown.onValueChanged.AddListener(ChangeBlock);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeBlock(int value)
    {
        Block.Type = (BlockTypes)value;
        Destroy(this.gameObject);   
    }
}
