using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartPickup : MonoBehaviour
{
    public GameObject carPart;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("PoppyPig");
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerPickUp>().inTrigger = true;
        player.GetComponent<PlayerPickUp>().inTriggerObject = this.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerPickUp>().inTrigger = false;
        player.GetComponent<PlayerPickUp>().inTriggerObject = null;
    }
}
