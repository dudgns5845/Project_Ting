using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox_SEJ : MonoBehaviour
{

    public Material mat; //��ī�̹ڽ� ���׸���
    float exposureAdg; //���Ⱚ ����
    void Start()
    { 
        //ó�� ��ī�̹ڽ��� ���Ⱚ
        exposureAdg = 0.4f;
    }

    void Update()
    {
        ChangeExposure();
    }
    void ChangeExposure()
    {
        mat = RenderSettings.skybox;
        mat.SetFloat("_Exposure", exposureAdg); //�ؽ���(�ƴϸ� ���̴�)������ ��ɾ �����
      
        if(exposureAdg > 0)
        {
            //exposureAdg += Time.fixedDeltaTime;
            exposureAdg += Time.deltaTime;

            if (exposureAdg >= 1.3f )
            {
                exposureAdg -= Time.deltaTime;
                exposureAdg = 0.35f;
            }
        }
       
    }

}
