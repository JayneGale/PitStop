using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachParts : MonoBehaviour
{
    public bool[] partsRequired;

    public GameObject tyre, hood;
    public CarController carCont;

    private void OnTriggerEnter(Collider other)
    {
        if (partsRequired[0])
        {
            if (other.GetComponent<PlayerPickUp>().carryTire)
            {
                other.GetComponent<PlayerPickUp>().carryTire = false;
                partsRequired[0] = false;
                tyre.SetActive(true);
                other.GetComponent<PlayerPickUp>().carryingPart[0].SetActive(false);
                other.GetComponent<PlayerPickUp>().isCarrying = false;
            }
        }

        if (partsRequired[1])
        {
            if (other.GetComponent<PlayerPickUp>().carryHood)
            {
                other.GetComponent<PlayerPickUp>().carryHood = false;
                partsRequired[1] = false;
                hood.SetActive(true);
                other.GetComponent<PlayerPickUp>().carryingPart[1].SetActive(false);
                other.GetComponent<PlayerPickUp>().isCarrying = false;
            }
        }
    }
}
