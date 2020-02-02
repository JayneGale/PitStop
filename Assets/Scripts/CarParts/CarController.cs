using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject[] carParts;
    public bool[] isPartThere;
    public bool repaired = false;
    // Start is called before the first frame update
    public Transform startPos;
    public Transform destination;
    // Movement speed in units per second.

    public Transform pitstop;
    public ScoreManagerV2 score;
    public bool haveScored;
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float repairedPath;
    private float comingtoShop;
    private float pitstopDist;
    private float fixedPathDist;
    public int scoreValue = 20;
    public float timeout = 30;
    private float timer;
    AudioManager AM;
    void Start()
    {
        gameObject.transform.position = startPos.position;
        repairedPath = Vector3.Distance(gameObject.transform.position, destination.position);
        comingtoShop = Vector3.Distance(gameObject.transform.position, pitstop.position);
        haveScored = false;
        timer = timeout;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var fixedpartcount = 0;
        for (int i = 0; i < carParts.Length; i++)
        {
            if (carParts[i].activeSelf)
            {
                isPartThere[i] = true;
                fixedpartcount++;
            }
        }
        if (fixedpartcount == carParts.Length)
        {
            repaired = true;
            if (haveScored == false)
            {
                score.ScoreUp(scoreValue);
                haveScored = true;
                AM.Play("Good");

            }
        }
        if (repaired)
        {
            //move the car closer
            //find the direction between gameObject.transform and destination
            //translate by some speed factor
            // Distance moved equals elapsed time multiplied by speed..
            fixedPathDist += speed * Time.deltaTime;
            // Fraction of journey completed equals current distance divided by total distance.
            float fixedJourneyPercent = fixedPathDist / repairedPath;
            if (fixedJourneyPercent < .90)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination.position, fixedJourneyPercent);
            }
            else
            {
                Recycle();
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer<0 && haveScored==false){
                score.ScoreDown(scoreValue);
                haveScored=true;
                Recycle();
            }
            pitstopDist += speed * Time.deltaTime;
            // Fraction of journey completed equals current distance divided by total distance.
            float fixedJourneyPercent = pitstopDist / comingtoShop;
            if (fixedJourneyPercent < .90)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, pitstop.position, fixedJourneyPercent);
            }
        }
    }
    /**
    * re start the state of the car to be used again.
    */
    private void Recycle()
    {
        haveScored = false;
        repaired = false;
        timer = timeout;
        gameObject.transform.position = startPos.position;
        pitstopDist=0;
        //do some logic to create broken parts
    }
}
