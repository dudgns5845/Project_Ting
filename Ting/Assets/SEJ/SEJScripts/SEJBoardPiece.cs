using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEJBoardPiece : MonoBehaviour
{
    public SEJDartBoard board;

    public int type;
    public int scoreNum;

    public void AddScorePlz(SEJDarts dart)
    {
        board.AddScore(dart, type, scoreNum);
    }


}
