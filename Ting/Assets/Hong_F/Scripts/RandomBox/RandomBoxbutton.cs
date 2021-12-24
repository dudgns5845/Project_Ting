using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBoxbutton : MonoBehaviour
{

    public Animator anim;
    int rand;

    public Text test;


    public List<string> Quation = new List<string>();

    List<int> Quation2 = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        Quation.Add("��� �� ���ɻ簡 �����ΰ���?");
        Quation.Add("����� ��ܺ��� ��Ʃ�� or �����ϴ� ��Ʃ����?");
        Quation.Add("����� MBTI��?");
        Quation.Add("�ݷ������� Ű��ó���?");
        Quation.Add("�ַ��� �󸶳� �ǽó���?");
        Quation.Add("���� ���� �ֳ���?");
        Quation.Add("�̻����� �ֳ���?");
        Quation.Add("����� �λ� ��ȭ or ��󸶴�?");
        Quation.Add("�丮�Ƿ��� ��������ΰ���?");
        Quation.Add("������ ������ �ȴٸ� �ϰ���� ���� �����ΰ���?");
        Quation.Add("�ڱ� �����ߴ� �� �� ��õ�ϰ� ���� ��������?");
        Quation.Add("������ ����ٸ� ������� ��Ҵ�?");
        Quation.Add("������ ���� ��� ����� �����ּ���!");



    }

    // Update is called once per frame
    void Update()
    {
        CameraRay();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            rand = Random.Range(0, Quation.Count);
            print(Quation[rand]);
            Quation.RemoveAt(rand);
            test.text = Quation[rand];

        }




    }

    void CameraRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo,100, 1 << LayerMask.NameToLayer("Button")))
            {

                if (Quation.Count == 0)
                {
                    test.text = "��� �������� ����ϼ̽��ϴ�.";
                    return;
                }

                rand = Random.Range(0, Quation.Count);
                anim.SetTrigger("ButtonClick");
                print(Quation[rand]);
                test.text = Quation[rand];
                Quation.RemoveAt(rand);

            }
           

        }


    }




}
