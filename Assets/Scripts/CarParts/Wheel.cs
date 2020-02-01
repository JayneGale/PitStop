using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Wheel : MonoBehaviour, IPickupable
{
    public string dropSoundName;
    public string itemName;
    [SerializeField]
    string itemID;
    AudioManager AM;
    string _itemID;

    public int ItemID
    {
        get
        {
            return this.ItemID;
        }
        set
        {
            this.name = _itemID;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
        AM.Play(dropSoundName);
        print("_itemID is " + _itemID);
    }

    public void Unwieldy(int UnwieldyFactor)
    {
        print("UnwieldyFactor is " + UnwieldyFactor);
    }
}
