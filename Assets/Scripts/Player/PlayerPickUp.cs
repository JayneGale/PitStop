using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public bool isCarrying;
    public bool carryTire;
    public bool carryHood;
    public GameObject[] carryingPart;

    public bool inTrigger;
    public GameObject inTriggerObject;

    public Animator _anim;

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
        if(inTriggerObject.GetComponent<PartPickup>().carPartEnum == CarPart.Tire)
        {
            carryTire = true;
            carryingPart[0].SetActive(true);
        }
        if (inTriggerObject.GetComponent<PartPickup>().carPartEnum == CarPart.Hood)
        {
            carryHood = true;
            carryingPart[1].SetActive(true);
        }
        _anim.SetBool("Carry", true);
    }

    public void ResetHold()
    {
        carryTire = false;
        carryHood = false;
        isCarrying = false;
        for (int i = 0; i < carryingPart.Length; i++)
        {
            carryingPart[i].SetActive(false);
        }
        _anim.SetBool("Carry", false);
    }
}
