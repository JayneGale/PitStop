using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachParts : MonoBehaviour
{
    public bool[] partsRequired;

    public GameObject tyre, hood;
    public PlayerPickUp playerPickup;
    public CarController carCont;

    private void OnTriggerEnter(Collider other)
    {
        if (partsRequired[0])
        {
            if (playerPickup.carryTire)
            {
                playerPickup.carryTire = false;
                partsRequired[0] = false;
                tyre.SetActive(true);
                playerPickup.carryingPart[0].SetActive(false);
                playerPickup.isCarrying = false;
            }
        }

        if (partsRequired[1])
        {
            if (playerPickup.carryHood)
            {
                playerPickup.carryHood = false;
                partsRequired[1] = false;
                hood.SetActive(true);
                playerPickup.carryingPart[1].SetActive(false);
                playerPickup.isCarrying = false;
            }
        }
    }
}
