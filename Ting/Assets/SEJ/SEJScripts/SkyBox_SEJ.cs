using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox_SEJ : MonoBehaviour
{

    public Material mat; //스카이박스 메테리얼
    float exposureAdg; //노출값 변수
    void Start()
    { 
        //처음 스카이박스의 노출값
        exposureAdg = 0.4f;
    }

    void Update()
    {
        ChangeExposure();
    }
    void ChangeExposure()
    {
        mat = RenderSettings.skybox;
        mat.SetFloat("_Exposure", exposureAdg); //텍스쳐(아니면 셰이더)에서는 명령어에 언더바
      
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
