using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Apple : MonoBehaviour
{
    public GameObject Apple;
    public GameObject System;
    Apple_Apple A_A;
    Vector3 MyPos;
    bool isApple = false;
    float ttime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Apple, transform).transform.parent = System.transform;
        Instantiate(Apple, transform).transform.parent = transform;
        MyPos = transform.position;
        A_A = GetComponentInChildren<Apple_Apple>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonUp(0)) // 마우스 왼쪽버튼을 떼면 하위오브젝트의 리지드바디에 있던 중력 값을 1로 설정함 기본상태는 0으로 설정해놨음
        {
            if(isApple == false)
            isApple = true;


            transform.GetChild(0).parent = System.transform;
        }


        if (isApple == true)
        {
            ttime += Time.deltaTime;

            if(ttime >= 2.5f)
            {
                Instantiate(Apple, transform).transform.parent = transform;
                isApple = false;
                ttime = 0f;
            }
        }
        
        

    }
}
