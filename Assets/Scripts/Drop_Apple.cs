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
            //���콺 ���� ��ư�� ������ ���÷��� �� ���� ������Ʈ�� �״� ��� ������Ʈ�� �ý��� ������Ʈ�� ���� ������Ʈ�� �����Ŵ
            if (isApple == false)
            {
                isApple = true; //���� ������Ʈ�� ��� ������Ʈ�� �Ѱ������Ƿ� �װ� üũ�ϱ����� ����� isApple�� true��Ŵ
            }
            if(transform.childCount > 0)
            {
                transform.GetChild(0).parent = System.transform;
            }
            
        }


        if (isApple == true) //2.5���� ��� ������Ʈ�� �ڽ��� ���� ������Ʈ�� ������Ŵ
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
