using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public bool isCarrying;
    public bool carryTire;
    public GameObject[] carryingPart;

    public bool inTrigger;
    public GameObject inTriggerObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isCarrying)
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
    }
}
