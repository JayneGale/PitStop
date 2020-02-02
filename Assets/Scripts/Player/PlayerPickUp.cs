using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public bool isCarrying;
    public bool carryWheel;
    public bool carryHood;
    public bool carryCabin;
    public bool carryBoot;


    public GameObject[] carryingPart;

    public bool inTrigger;
    public GameObject inTriggerObject;

    public Animator _anim;
    AudioManager AM;

    // Update is called once per frame
    public void Fire()
    {
        if (inTrigger)
        {
            if (!isCarrying)
            {
                isCarrying = true;
                PickUp();
            }
        }
    }

    void PickUp()
    {
        if(inTriggerObject.GetComponent<PartPickup>().carPartEnum == CarPart.Wheel)
        {
            carryWheel = true;
            carryingPart[0].SetActive(true);
        }
        if (inTriggerObject.GetComponent<PartPickup>().carPartEnum == CarPart.Hood)
        {
            carryHood = true;
            carryingPart[1].SetActive(true);
        }
        if (inTriggerObject.GetComponent<PartPickup>().carPartEnum == CarPart.Cabin)
        {
            carryCabin = true;
            carryingPart[2].SetActive(true);
        }
        if (inTriggerObject.GetComponent<PartPickup>().carPartEnum == CarPart.Boot)
        {
            carryBoot = true;
            carryingPart[3].SetActive(true);
        }

        FindObjectOfType<AudioManager>().Play("Click");
        _anim.SetBool("Carry", true);
    }

    public void ResetHold()
    {
        carryWheel = false;
        carryHood = false;
        carryCabin = false;
        carryBoot = false;
        isCarrying = false;
        for (int i = 0; i < carryingPart.Length; i++)
        {
            carryingPart[i].SetActive(false);
        }
        _anim.SetBool("Carry", false);
    }
}
