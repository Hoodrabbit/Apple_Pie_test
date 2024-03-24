using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_System : MonoBehaviour
{
    public GameObject[] Apples = new GameObject[5]; //���߿� ���� ī��Ʈ �� ���� ���� �������ָ� ���� ��
    public List<GameObject> Apples_List; 
    public int check_Now_State = 1;
    public int Apple_score = 0;
    public TextMeshProUGUI Give_Score_num;
    //enum���� �Ұ� �����ѵ� ���� ���¿��� ���� ���·� �Ѿ�� �������� 3���� ������ ��� ������

    public enum System_State
    {
        Apple_01,
        Apple_02,
        Apple_03,
        Apple_04,
    };


    public System_State Apple_State = System_State.Apple_01;
    //�̸����� �� üũ�ؼ� �����Ű�� ����� ����
    //�ٵ� �̹������ �ٸ� ����� ��������


    //public bool Check_ = false;

    void Start()
    {
        Apples_List = new List<GameObject>(Apples);
        
    }

    void Update()
    {
        Check_ChildCount();
        //Do_Merge();
        Give_Score_num.text = "�������� : " + Apple_score;


    }

    void Check_ChildCount() //�迭�ȿ� ���� ������Ʈ�� ���� ������Ʈ���� ���������� �־��ݴϴ�.
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Apples_List[i] == null)
            {
                Apples_List[i] = transform.GetChild(i).gameObject; 
            }

            if(Apples_List[Apples_List.Count-1] != null)
            {
                Apples_List.Add(null);//null ���� ����־ �߰�
            }
            //if(Apples_List.)
        }
    }

    //void Do_Merge()
    //{
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        Vector3 now_pos; //������ ��� ������Ʈ�� ���� ��ġ�� ��Ÿ���ֱ� ���� �����Ͽ����ϴ�.

    //        Check_Apple(Apples_List[i]);//�±� üũ�ؼ� ���� ��ȭ��Ŵ


    //        if(Apples_List[i] == null)
    //        {
    //            break;
    //        }
                

    //        //if (Apples_List[i] != null)
    //        //{
    //        //    if (Apples_List[i].GetComponent<Apple_Apple>().crash == true) //���� ���� �±׸� ���� ������Ʈ���� ���� �浹���� �� üũ�Ǵ� crash�� true�� ��쿡 ����˴ϴ�.
    //        //    {
    //        //        if (//������ ������ ���ؼ� ������ ������Ʈ�� �ϳ��� ������ �� �ֵ��� �մϴ�.(����� ������ ���� ������ 2�� �̻��� ������Ʈ�� ������)
    //        //            Apples_List[i].transform.position.x > Apples_List[i].GetComponent<Apple_Apple>().Crash_Obj.transform.position.x ||
    //        //            Apples_List[i].transform.position.y < Apples_List[i].GetComponent<Apple_Apple>().Crash_Obj.transform.position.y
    //        //            )
    //        //        {
    //        //            now_pos = Apples_List[i].transform.position;
    //        //            next_step = Apples_List[i].GetComponent<Apple_Apple>().next_Apple;//���� �浹�� ������Ʈ�� ���� �ܰ� ������Ʈ�� �������ݴϴ�.
    //        //            Destroy(Apples_List[i]); //������ �� ������Ʈ �� �ϳ��� ������ŵ�ϴ�.

    //        //            Destroy(Apples_List[i].GetComponent<Apple_Apple>().Crash_Obj); //���������� �� ������Ʈ�� �浹�� ������Ʈ�� �����մϴ�.

    //        //            Instantiate(next_step, now_pos, transform.rotation).transform.parent = transform; //���� �ܰ��� ������Ʈ�� System������Ʈ�� ���� ������Ʈ�� �����մϴ�.

    //        //            break; //�̹� ������ ������Ʈ�� �����Ͽ� ������ �Ͼ�� ������ �ݺ����� ���������� ���� ����Ͽ����ϴ�. 


    //        //        }
    //        //    }
    //        //}
            
    //    }
    //}

    void Check_Apple(GameObject APPLE)
    {
        if(APPLE.tag == "Apple_02")
        {
            //�ٵ� �±׷� �����Ű�� �̰� �� ���������� Ȯ���ϸ鼭 �±װ� ��� �ٲ�
        }
    }


}
