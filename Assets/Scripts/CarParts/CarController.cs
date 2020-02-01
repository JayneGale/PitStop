using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject[] carParts;
    public bool[] isPartThere;
    public bool repaired = false;
    // Start is called before the first frame update
    public Transform destination;
        // Movement speed in units per second.

    public Transform pitstop;
    public ScoreManager score;
    public bool haveScored;
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(gameObject.transform.position,destination.position);
        haveScored =false;
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
        if(fixedpartcount == carParts.Length){
            repaired =true;
            if(haveScored==false){   
                score.scoreUp();
                haveScored =true;
            }
        }
        if(repaired){
            //move the car closer
            //find the direction between gameObject.transform and destination
            //translate by some speed factor
            // Distance moved equals elapsed time multiplied by speed..
            float distCovered = (Time.time - startTime) * speed* Time.deltaTime;
            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination.position, fractionOfJourney);
        }
    }
}
