using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* 
 * ==============================================================================
 * 功能描述：箱子类
 * 创 建 者：JN_X
 * 创建日期：2019年7月17日
 * ==============================================================================
 */
[RequireComponent(typeof(Image),typeof(BoxCollider2D))]
public class Chest : MonoBehaviour
{
    public bool IsOnPoint;
    public bool IsTouching;

    public Sprite Empty;
    public Sprite Full;

    public Image Image;

    public BoxCollider2D BoxCollider;

    public Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider = this.GetComponent<BoxCollider2D>();
        Image = this.GetComponent<Image>();
        Rigidbody = this.GetComponent<Rigidbody2D>();

        BoxCollider.size = new Vector2(82,82);

        Empty = Resources.Load<Sprite>("empty");
        Full = Resources.Load<Sprite>("full");

        Image.sprite = Empty;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnDrag()
    {
        if (PlayerPrefs.GetString("ReadMap") == "0")
        {
            this.transform.position = Input.mousePosition;

        }

    }

    //推箱子的碰撞器
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            IsOnPoint = true;
            Image.sprite = Full;
        }
        else
        {
            if (collision.tag == "Ground"&&!IsTouching)
            {
                Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            IsOnPoint = true;
            Image.sprite = Full;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            IsOnPoint = false;
            Image.sprite = Empty;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            IsTouching = true;
            if (Input.GetKey(KeyCode.W))
            {
                Rigidbody.AddForce(new Vector2(0, 1 * Time.deltaTime));
                Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Rigidbody.AddForce(new Vector2(0-1 * Time.deltaTime,0));
                Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Rigidbody.AddForce(new Vector2(0, 0-1 * Time.deltaTime));
                Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Rigidbody.AddForce(new Vector2(1 * Time.deltaTime,0));
                Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
            Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            IsTouching = false;
        }
    }
}
