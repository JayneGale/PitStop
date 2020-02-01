using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachParts : MonoBehaviour
{
    public bool[] partsRequired;

    public GameObject tyre, hood;
    public CarController carCont;
    PlayerPickUp pickup;

    private void OnTriggerEnter(Collider other)
    {
        if (partsRequired[0])
        {
            pickup = other.GetComponent<PlayerPickUp>();
            if (pickup == null) print("pickup is null");
            else 
            {
                if (pickup.carryTire)
                {
                    pickup.carryTire = false;
                    partsRequired[0] = false;
                    tyre.SetActive(true);
                    pickup.carryingPart[0].SetActive(false);
                    pickup.isCarrying = false;
                }
            }
        }

        if (partsRequired[1])
        {
            pickup = other.GetComponent<PlayerPickUp>();
            if (pickup == null)  print("pickup is null");
            else
            {
                if (pickup.carryHood)
                {
                    pickup = other.GetComponent<PlayerPickUp>();

                    pickup.carryHood = false;
                    partsRequired[1] = false;
                    hood.SetActive(true);
                    pickup.carryingPart[1].SetActive(false);
                    pickup.isCarrying = false;
                }

            }
        }
    }
}
