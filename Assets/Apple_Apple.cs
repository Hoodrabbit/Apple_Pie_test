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

                //지금 이렇게 만들면 이 위치로 바로 순간이동 해버리기 때문에 이렇게가 아니라 서서히 이동하는 것처럼 보이도록 해야함
                transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
                //transform.position = new Vector2(screento, transform.position.y);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == transform.tag)
        {
            //다른 오브젝트를 생성 현재 자신 오브젝트의 위치에다가 생성
            //하나는 삭제하고 하나만 남겨야함
            //복제하기 전에 실행되어야 함
            //Destroy(collision.gameObject);
            //G_S.Check_ = true;
            crash = true;
            Crash_Obj = collision.gameObject;
        }
    }

    //void Ontrigger
    //static 



}
