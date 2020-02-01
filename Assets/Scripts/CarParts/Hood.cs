using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hood : Pickupable
{
    AudioManager AM;

    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
        AM.Play(dropSoundName);
        print("_itemID is " + itemID);
        Unwieldy(unwieldyFactor);
    }

    public override void Unwieldy(int UnwieldyFactor)
    {
        print("UnwieldyFactor second override is " + UnwieldyFactor + itemID + itemName);
    }

}
