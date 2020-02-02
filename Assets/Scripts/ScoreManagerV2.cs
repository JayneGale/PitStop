using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManagerV2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public float time;
    public Image[] stars;
    public List<List<int>> test;
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
        UpdateScoreCard();
        timerText.text = (Mathf.Round(time * 100)/100).ToString();
    }
    public void UpdateTimeLeft(float timeLeft)
    {
        time = timeLeft;
    }

    public void UpdateScoreCard()
    {
        foreach(Image star in stars)
        {
            star.enabled = false;
        }
        int startIndex = 0;
        foreach(int count in GetStarCounts())
        {
            for(int i = 0; i < count; i++)
            {
                stars[startIndex + i].enabled = true;
            }
            startIndex += 4;
        }
    }

    List<int> GetStarCounts()
    {
        //Breakout if score is 0
        if (score == 0) { return new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }); }
        //Calculate Stars
        List<int> startCount = new List<int>();
        int[] scoreIntervals = new int[] { 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };
        int tempScore = score;
        foreach (int scoreInterval in scoreIntervals)
        {

            int testTempScore = tempScore;
            int amount = -1;
            while (testTempScore >= 0)
            {
                amount += 1;
                testTempScore -= scoreInterval;
            }
            startCount.Add(amount);
            tempScore -= amount * scoreInterval;
        }
        return startCount;
    }

    void PrintIntList(List<int> intList)
    {
        string printOutString = "";
        foreach (int i in intList)
        {
            printOutString += i.ToString() + ", ";
        }
        printOutString += ":END";
        print(printOutString);
    }
}

[System.Serializable]
public struct StarSprites
{
    public string name;
    public Image[] sprites;
}
