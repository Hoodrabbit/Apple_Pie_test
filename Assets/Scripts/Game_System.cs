using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_System : MonoBehaviour
{
    public GameObject[] Apples = new GameObject[20]; //���߿� ���� ī��Ʈ �� ���� ���� �������ָ� ���� ��
    public GameObject next_step;
    public bool Check_ = false;
    bool Do_instantiate = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.childCount);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Apples[i] == null)
            {
                Apples[i] = transform.GetChild(i).gameObject; //�迭�ȿ� ���� ������Ʈ�� ���� ������Ʈ���� ���������� �־���;
            }

        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 now_pos;
            if (Apples[i].GetComponent<Apple_Apple>().crash == true)
            {
                if (Apples[i].transform.position.x > Apples[i].GetComponent<Apple_Apple>().Crash_Obj.transform.position.x || Apples[i].transform.position.y < Apples[i].GetComponent<Apple_Apple>().Crash_Obj.transform.position.y)
                {
                    now_pos = Apples[i].transform.position;
                    Do_instantiate = true;
                    Destroy(Apples[i]);
                    Destroy(Apples[i].GetComponent<Apple_Apple>().Crash_Obj);
                    if (Do_instantiate == true)
                    {
                        Instantiate(next_step, now_pos, transform.rotation).transform.parent = transform;

                        Do_instantiate = false;

                        break;

                    }

                }
            }





        }

        //if (Do_instantiate == true)
        //{
        //    Instantiate(next_step, Vector3.zero, transform.rotation).transform.parent = transform;
        //    Do_instantiate = false;
        //}


        //if (Check_ == true)
        //{
        //    Transform[] child_objs = GetComponentsInChildren<Transform>();
        //    foreach(Transform obj in child_objs)
        //    {
        //        Destroy(obj.gameObject);
        //    }
        //}


    }






}
