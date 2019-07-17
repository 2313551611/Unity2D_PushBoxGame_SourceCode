using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 * ==============================================================================
 * 功能描述：玩家的移动 
 * 创 建 者：JN_X
 * 创建日期：2019年7月17日
 * ==============================================================================
 */
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //移动
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            if (Input.GetKey(KeyCode.W))
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000 * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0 - 1000 * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0 - 1000 * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000 * Time.deltaTime, 0));
            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
