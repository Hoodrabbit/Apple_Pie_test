using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Apple : MonoBehaviour
{
    bool isGrab = false;
    public bool crash = false;
    public GameObject next_Apple;
    public GameObject Crash_Obj;
    Rigidbody2D apple_rigid;

    public enum Apple_State
    { 
        None,
        Grab,
        UnGrab
    };

    public Apple_State A_S;

     //Game_System G_S;

    // Start is called before the first frame update
    void Start()
    {
        apple_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.name == "Player")
        {
            A_S = Apple_State.Grab;
        }
        
        if(transform.parent.name == "System")
        {
            A_S = Apple_State.UnGrab;
            apple_rigid.gravityScale = 1;
        }
        //if(isGrab == true && A_S == Apple_State.None)
        //{
        //    A_S = Apple_State.Grab;
        //}

        if(A_S == Apple_State.Grab)
        {
            if (Input.GetMouseButton(0))
            {

                //���� �̷��� ����� �� ��ġ�� �ٷ� �����̵� �ع����� ������ �̷��԰� �ƴ϶� ������ �̵��ϴ� ��ó�� ���̵��� �ؾ���
                transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
                //transform.position = new Vector2(screento, transform.position.y);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == transform.tag)
        {
            //�ٸ� ������Ʈ�� ���� ���� �ڽ� ������Ʈ�� ��ġ���ٰ� ����
            //�ϳ��� �����ϰ� �ϳ��� ���ܾ���
            //�����ϱ� ���� ����Ǿ�� ��
            //Destroy(collision.gameObject);
            //G_S.Check_ = true;
            crash = true;
            Crash_Obj = collision.gameObject;
        }
    }

    //void Ontrigger
    //static 



}
