using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachParts : MonoBehaviour
{
    public GameObject neededPart;
    public GameObject tyre;
    private void OnTriggerEnter(Collider other)
    {
        if(GameObject.Find("PoppyPig").GetComponent<PlayerPickUp>().carriedObject = neededPart)
        {
            Destroy(GameObject.Find("PoppyPig").GetComponent<PlayerPickUp>().carriedObject);
            GameObject.Find("PoppyPig").GetComponent<PlayerPickUp>().carriedObject = null;
            tyre.SetActive(true);
        }
    }
}
