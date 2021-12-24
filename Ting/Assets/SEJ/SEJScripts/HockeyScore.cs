using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HockeyScore : MonoBehaviour
{
    public Text txtScore;
    
    public int currScore;
    public int totalScore;

    public bool getScore;
    
    
    HockeyGoal isgoal;

    

    void Start()
    {
        txtScore.text = currScore + " : " + currScore;
    }

    void Update()
    {
        //µÊ¡°«ﬂ¿ª ∂ß 
    }
}
