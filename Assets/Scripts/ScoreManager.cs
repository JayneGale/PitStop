using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public float time;
    public Text scoreText;
    public Text timerText;
    void Start()
    {
        score =0;
    }
    public void ScoreUp(int amount)
    {
        score += amount;
    }
    public void ScoreDown(int amount)
    {
        ScoreUp(-amount);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text= "SCORE: " + score;
        timerText.text = (Mathf.Round(time * 100)/100).ToString();
    }
    public void UpdateTimeLeft(float timeLeft)
    {
        time = timeLeft;
    }
}
