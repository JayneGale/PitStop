using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text scoreText;
    void Start()
    {
        score =0;
    }
    public void scoreUp(){
        score++;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text= "SCORE: " + score;
    }
}
