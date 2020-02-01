using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject[] carParts;
    public bool[] isPartThere;
    public GameObject[] attachPartTrigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < carParts.Length; i++)
        {
            if (carParts[i].activeSelf)
            {
                isPartThere[i] = true;
            }
        }
    }
}
