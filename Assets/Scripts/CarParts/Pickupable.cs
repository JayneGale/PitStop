using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class Pickupable : MonoBehaviour
{
    public int itemID;
    public string dropSoundName;
    public string itemName;
    AudioManager AM;
    public int unwieldyFactor;

    private void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }

    public virtual void Unwieldy(int UnwieldyFactor)
    {
        print("UnwieldyFactor is " + UnwieldyFactor);
        AM.Play(dropSoundName);
    }


}
