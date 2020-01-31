using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachParts : MonoBehaviour
{
    public GameObject tyre;
    public PlayerPickUp playerPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (playerPickup.carryTire)
        {
            playerPickup.carryTire = false;
            tyre.SetActive(true);
            playerPickup.carryingPart[0].SetActive(false);
            playerPickup.isCarrying = false;
        }
    }
}
