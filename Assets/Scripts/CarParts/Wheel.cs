using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wheel :  Pickupable 
{
    //AudioManager AM;

    void Start()
    {
        //AM = FindObjectOfType<AudioManager>();
        print(dropSoundName);
        //print("itemID is " + itemID + itemName);
        Unwieldy(unwieldyFactor);
    }

    public override void Unwieldy(int UnwieldyFactor)
    {
        print("UnwieldyFactor override  method is " + UnwieldyFactor + itemName + itemID);
        //AM.Play(dropSoundName);
    }
}
