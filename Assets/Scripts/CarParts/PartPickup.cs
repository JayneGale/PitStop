using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartPickup : MonoBehaviour
{
    public GameObject carPart;
    public PlayerPickUp playerPickup;

    private void Start()
    {
        playerPickup = GameObject.Find("PoppyPig").GetComponent<PlayerPickUp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerPickup.inTrigger = true;
        playerPickup.inTriggerObject = this.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        playerPickup.inTrigger = false;
        playerPickup.inTriggerObject = null;
    }
}
