using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEJTrail : MonoBehaviour
{
    public Camera cam; //메인캠    
    public Material defaultMaterial; //Material for Line Renderer
    public GameObject board; //그림판

    private LineRenderer curLine; //현재 그려지는 라인
    private int positionCount = 2;  //처음값과 끝값
    private Vector3 PrevPos = Vector3.zero; // 0,0,0 가변적인 위치


    void Update()
    {
        DrawMouse();
    }

    void DrawMouse()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f));
        
        if (Input.GetMouseButtonDown(0))
        {
            createLine(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            connectLine(mousePos);
        }
         
    }

    private void connectLine(Vector3 mousePos)
    {
        if (PrevPos != null && Mathf.Abs(Vector3.Distance(PrevPos, mousePos)) >= 0.001f)
        {
            PrevPos = mousePos;
            positionCount++;
            curLine.positionCount = positionCount;
            curLine.SetPosition(positionCount - 1, mousePos);
        }
    }

    private void createLine(Vector3 mousePos)
    {
        positionCount = 2;
        GameObject line = new GameObject("Line");
        LineRenderer lineRend = line.AddComponent<LineRenderer>();
        BoxCollider brush = new GameObject("Brush").AddComponent<BoxCollider>();
        brush.transform.parent = line.transform;


        line.transform.parent = cam.transform;
        line.transform.position = mousePos;

        lineRend.startWidth = 0.005f;
        lineRend.endWidth = 0.005f;
        lineRend.numCornerVertices = 5;
        lineRend.numCapVertices = 5;
        lineRend.material = defaultMaterial;
        lineRend.SetPosition(0, mousePos);
        lineRend.SetPosition(1, mousePos);

        curLine = lineRend;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}
