using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Apple : MonoBehaviour
{
    public bool crash = false;
    bool Merge = false;

    Vector3 middle_pos = Vector3.zero;

    public GameObject Score_text;
    public GameObject next_Apple;
    public GameObject Crash_Obj;
    public Game_System G_S;
    Rigidbody2D apple_rigid;
    int Apple_Score = 1;

    float aa =0;

    public enum Apple_Grab_State
    { 
        None,
        Grab,
        UnGrab
    };

    public enum Apple_state
    {
        first =1,
        second,
        thrid,
        fourth,
        fifth,
        sixth,
        seventh,
        eighth
    };


    public Apple_state A_S;

    public Apple_Grab_State A_G_S;

    void Start()
    {
       apple_rigid = GetComponent<Rigidbody2D>();
        G_S = GetComponentInParent<Game_System>();//그랩 되어있는 변수는 영향을 못받음 그래서 의미가 크게 없음
        CheckState();
    }

    void Update()
    {
        Check_name();

        if (A_G_S == Apple_Grab_State.Grab)
        {
            IsGrab();
        }


        if(crash == true && A_S != Apple_state.eighth)
        {
            Apple_Contact(Crash_Obj);
        }
        
    }

    void Check_name()
    {
        if (transform.parent.name == "Player")
        {
            A_G_S = Apple_Grab_State.Grab;
        }

        if (transform.parent.name == "System")
        {
            A_G_S = Apple_Grab_State.UnGrab;
            apple_rigid.gravityScale = 4;
        }
    }

    void IsGrab()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 Test = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -10.5f, 10.5f), transform.position.y);
            //x값이 특정 범위를 벗어나면 그대로 맵 밖으로 벗어나기 때문에 일정 값 이하까지만 가능하도록
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
            //지금 이렇게 만들면 이 위치로 바로 순간이동 해버리기 때문에 이렇게가 아니라 서서히 이동하는 것처럼 보이도록 해야함
            transform.position = Vector2.Lerp(transform.position, Test, 5 * Time.deltaTime);
        }
    }


    void Apple_Contact(GameObject crash_obj)
    {
        if(crash == true)
        {
            if(transform.position.x < crash_obj.transform.position.x || transform.position.y < crash_obj.transform.position.y)
            {
                if (Merge == false)
                {
                    middle_pos = new Vector3((crash_obj.transform.position.x + transform.position.x) / 2, (crash_obj.transform.position.y + transform.position.y) / 2 - 1, 0); //중심값을 구해서 최대한 벽에 충돌하지 않도록
                    Merge = true;
                }
                
                //lerp시켜서 일정 거리 이상 온다음에 destroy및 복제시키도록 하면 되지 않을까
                //Physics2D.IgnoreCollision(gameObject.GetComponentInChildren<CircleCollider2D>(), crash_obj.GetComponentInChildren<CircleCollider2D>(),true);
                Vector3.Lerp(crash_obj.transform.position, middle_pos, 100* Time.deltaTime);
                Vector3.Lerp(transform.position, middle_pos, 100 * Time.deltaTime);
                aa += 2 * Time.deltaTime;
                //Debug.Log(aa);
                if(aa >=0.5f)//약간의 딜레이
                {
                    DestroyAndScore(crash_obj);
                    Instantiate(next_Apple, middle_pos, Quaternion.identity, transform.parent); // 이걸 시스템에서 만들어줌 사과 상태에 따라 복제가 될지 안될지 결정함 마지막 단계라면 복제를 당연히 못하니 하지 않도록
                    DestroyAndScore(gameObject);
                    
                    crash = false;
                }
                //Debug.Log("실행됨");
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == transform.tag)
        {
            crash = true;
            Crash_Obj = collision.gameObject;
            
            Debug.Log("충돌");
            //충돌 처리가 너무 많이 일어나기 때문에 이렇게 말고 생성될 때 점수를 올리는 식으로 하자
            //Apple_Contact(Crash_Obj);
            
        }
    }

    void CheckState()
    {
        switch (A_S)
        {
            case Apple_state.first:
                {
                    //각 상태마다의 기본 설정을 해줌
                    Apple_Score = 1;
                    break;
                }
                
            case Apple_state.second:
                {
                    Apple_Score = 2;
                    break;
                }
                
            case Apple_state.thrid:
                {
                    Apple_Score = 3;
                    break;
                }
                
            case Apple_state.fourth:
                {
                    Apple_Score = 4;
                    break;
                }
                
            case Apple_state.fifth:
                {
                    Apple_Score = 5;
                    break;
                }

            case Apple_state.sixth:
                {
                    Apple_Score = 6;
                    break;
                }

            case Apple_state.seventh:
                {
                    Apple_Score = 7;
                    break;
                }

            case Apple_state.eighth:
                {
                    Apple_Score = 8;
                    break;
                }
        }
    }

    //public void 
    void DestroyAndScore(GameObject myApple)
    {
        if(G_S == null)
        {
            G_S = GetComponentInParent<Game_System>();
        }
        G_S.Apple_score += myApple.GetComponent<Apple_Apple>().Apple_Score;
        Destroy(myApple);

            
    }

    void Set_State_num()
    {
        if(G_S.check_Now_State > (int)A_S)
        {
            G_S.check_Now_State = (int)A_S;
        }
    }
    


}
