using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ִٰ� �ɾ������� �Ӹ� ��ġ

public class SEJHeadPos : MonoBehaviour
{
    public Transform firstPos;
    public Transform lastPos;
    public Transform ovrCamTrackingSpace;
    public float speed=0;
    bool isSit;
    void Start()
    {
        ovrCamTrackingSpace.position = firstPos.position;
        ovrCamTrackingSpace.rotation = firstPos.rotation;
    }

    void Update()
    {
        if(isSit)
        {
            ovrCamTrackingSpace.position = Vector3.Lerp(firstPos.position, lastPos.position, speed);
        }
    }
    public void MoveHead()
    {
        isSit = true;
    }

}
