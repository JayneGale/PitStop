using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachParts : MonoBehaviour
{
    public GameObject neededPart;
    public GameObject tyre;
    PlayerPickUp playerPickup;
    private void Start()
    {
        playerPickup = GameObject.Find("PoppyPig").GetComponent<PlayerPickUp>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (playerPickup.carriedObject = neededPart)
        {
            Destroy(playerPickup.carriedObject);
            playerPickup.carriedObject = null;
            tyre.SetActive(true);
        }
    }
}
