using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Apple : MonoBehaviour
{
    public GameObject[] Apple;
    public GameObject System;
    public Game_System G_S;

    bool isApple = false;
    float ttime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Apple, transform).transform.parent = System.transform;
        Instantiate(Apple[0], transform).transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        IsApple_Grab();
    }

    void IsApple_Grab()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //마우스 왼쪽 버튼을 누르고 들어올렸을 때 하위 오브젝트로 뒀던 사과 오브젝트를 시스템 오브젝트의 하위 오브젝트로 변경시킴
            if (isApple == false)
            {
                isApple = true; //하위 오브젝트가 사과 오브젝트가 넘겨줬으므로 그걸 체크하기위해 사용한 isApple을 true시킴
            }
            if(transform.childCount > 0)
            {
                transform.GetChild(0).parent = System.transform;
            }
            
        }


        if (isApple == true) //2.5초후 사과 오브젝트를 자신의 하위 오브젝트에 생성시킴
        {
            ttime += Time.deltaTime;

            if (ttime >= 2.5f)
            {
                Choose_Apple();
                isApple = false;
                ttime = 0f;
            }
        }
    }

    void Choose_Apple()
    {
        switch (G_S.check_Now_State)
        {
            case >= 6:
                {
                    Instantiate(Apple[(int)Random.Range(0f, 4f)], transform).transform.parent = transform;
                    break;
                }

            default:
                {
                    Instantiate(Apple[(int)Random.Range(0f, 3f)], transform).transform.parent = transform;
                }
                break;
        }
    }





}
