using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public bool isCarrying;
    public GameObject carriedObject;

    public bool inTrigger;
    public GameObject inTriggerObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isCarrying)
            {
                isCarrying = true;
                carriedObject = Instantiate(inTriggerObject.GetComponent<PartPickup>().carPart, this.gameObject.transform.position + new Vector3(0,3,0), Quaternion.identity);
                carriedObject.transform.parent = this.gameObject.transform;
                carriedObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void PickUp()
    {

    }
}
