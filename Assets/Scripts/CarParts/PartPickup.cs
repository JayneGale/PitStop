﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarPart
{
    Tire,
    Hood
}

public class PartPickup : MonoBehaviour
{
    public CarPart carPartEnum;
    public PlayerPickUp playerPickup;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerPickUp>().inTrigger = true;
        other.GetComponent<PlayerPickUp>().inTriggerObject = this.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerPickUp>().inTrigger = false;
        other.GetComponent<PlayerPickUp>().inTriggerObject = null;
    }
}
