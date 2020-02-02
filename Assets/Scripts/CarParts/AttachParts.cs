using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachParts : MonoBehaviour
{
    public bool[] partsRequired;

    public GameObject wheel, hood, cabin, boot;
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
                if (pickup.carryWheel)
                {
                    pickup.carryWheel = false;
                    partsRequired[0] = false;
                    wheel.SetActive(true);
                    pickup.carryingPart[0].SetActive(false);
                    pickup.isCarrying = false;
                }
            }
        }

        if (partsRequired.Length>1 && partsRequired[1])
        {
            pickup = other.GetComponent<PlayerPickUp>();
            if (pickup == null)  print("pickup is null");
            else
            {
                if (pickup.carryHood)
                {
                    pickup = other.GetComponent<PlayerPickUp>();

                    partsRequired[1] = false;
                    hood.SetActive(true);
                    pickup.ResetHold();
                }

            }
        }
    }
}
