using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_System : MonoBehaviour
{
    public GameObject[] Apples = new GameObject[5]; //나중에 따로 카운트 할 변수 만들어서 설정해주면 좋을 듯
    public List<GameObject> Apples_List; 
    public int check_Now_State = 1;
    public int Apple_score = 0;
    public TextMeshProUGUI Give_Score_num;
    //enum으로 할것 같긴한데 현재 상태에서 다음 상태로 넘어가면 랜덤으로 3가지 내에서 사과 떨어짐

    public enum System_State
    {
        Apple_01,
        Apple_02,
        Apple_03,
        Apple_04,
    };


    public System_State Apple_State = System_State.Apple_01;
    //이름으로 다 체크해서 적용시키는 방법이 있음
    //근데 이방법말고 다른 방법은 없으려나


    //public bool Check_ = false;

    void Start()
    {
        Apples_List = new List<GameObject>(Apples);
        
    }

    void Update()
    {
        Check_ChildCount();
        //Do_Merge();
        Give_Score_num.text = "현재점수 : " + Apple_score;


    }

    void Check_ChildCount() //배열안에 현재 오브젝트의 하위 오브젝트들을 순차적으로 넣어줍니다.
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Apples_List[i] == null)
            {
                Apples_List[i] = transform.GetChild(i).gameObject; 
            }

            if(Apples_List[Apples_List.Count-1] != null)
            {
                Apples_List.Add(null);//null 값을 집어넣어서 추가
            }
            //if(Apples_List.)
        }
    }

    //void Do_Merge()
    //{
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        Vector3 now_pos; //합쳐진 사과 오브젝트의 생성 위치를 나타내주기 위해 선언하였습니다.

    //        Check_Apple(Apples_List[i]);//태그 체크해서 상태 변화시킴


    //        if(Apples_List[i] == null)
    //        {
    //            break;
    //        }
                

    //        //if (Apples_List[i] != null)
    //        //{
    //        //    if (Apples_List[i].GetComponent<Apple_Apple>().crash == true) //서로 같은 태그를 지닌 오브젝트들이 서로 충돌했을 때 체크되는 crash가 true일 경우에 실행됩니다.
    //        //    {
    //        //        if (//간단한 조건을 통해서 합쳐진 오브젝트가 하나씩 생성될 수 있도록 합니다.(제대로 조건을 걸지 않으면 2개 이상의 오브젝트가 생성됨)
    //        //            Apples_List[i].transform.position.x > Apples_List[i].GetComponent<Apple_Apple>().Crash_Obj.transform.position.x ||
    //        //            Apples_List[i].transform.position.y < Apples_List[i].GetComponent<Apple_Apple>().Crash_Obj.transform.position.y
    //        //            )
    //        //        {
    //        //            now_pos = Apples_List[i].transform.position;
    //        //            next_step = Apples_List[i].GetComponent<Apple_Apple>().next_Apple;//현재 충돌한 오브젝트의 다음 단계 오브젝트를 저장해줍니다.
    //        //            Destroy(Apples_List[i]); //합쳐진 두 오브젝트 중 하나를 삭제시킵니다.

    //        //            Destroy(Apples_List[i].GetComponent<Apple_Apple>().Crash_Obj); //마찬가지로 위 오브젝트와 충돌한 오브젝트를 삭제합니다.

    //        //            Instantiate(next_step, now_pos, transform.rotation).transform.parent = transform; //다음 단계의 오브젝트를 System오브젝트의 하위 오브젝트로 생성합니다.

    //        //            break; //이미 삭제된 오브젝트에 접근하여 오류가 일어나기 때문에 반복문을 빠져나오기 위해 사용하였습니다. 


    //        //        }
    //        //    }
    //        //}
            
    //    }
    //}

    void Check_Apple(GameObject APPLE)
    {
        if(APPLE.tag == "Apple_02")
        {
            //근데 태그로 적용시키면 이게 다 순차적으로 확인하면서 태그가 계속 바뀜
        }
    }


}
